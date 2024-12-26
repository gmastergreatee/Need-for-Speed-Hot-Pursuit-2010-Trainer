using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
