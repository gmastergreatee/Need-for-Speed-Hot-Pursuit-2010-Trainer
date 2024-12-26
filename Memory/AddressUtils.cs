using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class AddressUtils
    {
        public static byte[] AddressToBytes(uint address)
        {
            throw new NotImplementedException();
        }

        public static uint AddressBytesToString(byte[] addressBytes)
        {
            throw new NotImplementedException();
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
