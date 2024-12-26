using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Memory.Core;

namespace Memory
{
    public class AddressUtils
    {
        public static IEnumerable<byte> AddressToBytes(uint address)
        {
            return BitConverter.GetBytes(address).Reverse();
        }

        public static uint AddressBytesToString(IEnumerable<byte> addressBytes)
        {
            return BitConverter.ToUInt32(addressBytes.ToArray(), 0);
        }

        public static UInt32? AddressStringToNumber(string address, Process process)
        {
            address = address.Replace("\"", "").Replace(Environment.NewLine, "").Replace(" ", "").Trim();
            if (address.Contains('+') && process != null)
            {
                UInt32 baseAddress = 0;
                var spl = address.Split('+');
                var moduleName = spl[0].Replace(".exe", "").Replace(".dll", "");
                foreach (ProcessModule module in process.Modules)
                {
                    if (Path.GetFileNameWithoutExtension(module.FileName) == moduleName)
                    {
                        baseAddress += (uint)module.BaseAddress;
                        break;
                    }
                }
                return baseAddress + Convert.ToUInt32(spl[1], 16);
            }

            try
            {
                return Convert.ToUInt32(address, 16);
            }
            catch { }

            return null;
        }

        public static IEnumerable<byte> BytesForJumpAddress(uint jumpDestination, uint addressWhereToPlaceBytes)
        {
            // maybe need to change in 64 bit process
            var addressByteLengthInMemory = 4;
            var final = jumpDestination - addressWhereToPlaceBytes - addressByteLengthInMemory;
            return BitConverter.GetBytes(final).Take(addressByteLengthInMemory);
        }

        public static string ParseAsm_CreateLabels(UInt32 startAddress, string asmBytes)
        {
            asmBytes = asmBytes.Replace(" ", "").Replace(Environment.NewLine, "").Trim();
            var finalString = asmBytes;
            var index = 0;
            var byteOffset = 0;
            while (index < asmBytes.Length)
            {
                var counter = 2;

                if (asmBytes[index] == '{')
                {
                    var lastIndex = asmBytes.IndexOf("}", index, asmBytes.Length - index, StringComparison.Ordinal);
                    var labelName = asmBytes.Substring(index + 1, lastIndex - index - 1);
                    if (labelName.StartsWith(':'))
                    {
                        // means this is a jump point
                        StaticVars.AddLabel(labelName.Substring(1), startAddress + (UInt32)byteOffset);
                        finalString = finalString.Replace($"{{{labelName}}}", "");
                        byteOffset--;
                    }
                    else
                    {
                        byteOffset += 3;
                    }
                    counter = labelName.Length + 2;
                }

                index += counter;
                byteOffset++;
            }
            return finalString;
        }

        public static string ParseAsm_AssignLabels(UInt32 startAddress, string asmBytes)
        {
            asmBytes = asmBytes.Replace(" ", "").Replace(Environment.NewLine, "").Trim();
            var finalString = asmBytes;
            var index = 0;
            var bytesOffset = 0;
            while (index < asmBytes.Length)
            {
                var counter = 2;

                if (asmBytes[index] == '{')
                {
                    var lastIndex = asmBytes.IndexOf("}", index, asmBytes.Length - index, StringComparison.Ordinal);
                    var labelName = asmBytes.Substring(index + 1, lastIndex - index - 1);
                    var labelSplit = labelName.Split(',');

                    var replaceString = "";
                    var existingLabel = StaticVars.GetLabelAddress(labelSplit[0]);

                    if (existingLabel == null)
                    {
                        throw new Exception($"Could not get address of label \"{labelName}\"");
                    }

                    IEnumerable<byte>? addressBytes = null;
                    string labelType = labelSplit.Length > 1 ? labelSplit[1] : "Jump";

                    // types of labels, => Jump(default), Var
                    if (string.Compare(labelType, "Var", true) == 0)
                    {
                        addressBytes = AddressToBytes(existingLabel.Value).Reverse();
                    }
                    else
                    {
                        addressBytes = BytesForJumpAddress(existingLabel.Value, startAddress + (uint)bytesOffset);
                    }

                    if (addressBytes == null)
                    {
                        throw new Exception($"Unable to calculate addressBytes for label \"{labelName}\"");
                    }

                    replaceString = String.Join("", addressBytes.Select(i => i.ToString("X").PadLeft(2, '0')));

                    var regex = new Regex(Regex.Escape($"{{{labelName}}}"));
                    finalString = regex.Replace(finalString, replaceString, 1);

                    counter = labelName.Length + 2;
                    bytesOffset += 3;
                }

                index += counter;
                bytesOffset++;
            }
            return finalString;
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "").Replace(Environment.NewLine, "").Trim();
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            var data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                var byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
    }
}
