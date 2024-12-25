namespace Memory.Core.Models
{
    internal class CodeCaveBytes
    {
        public required string RangeName { get; set; }
        public required byte[] Bytes { get; set; }

        public int GetStartAddress()
        {
            var addressOffset = 0;
            foreach (var codeCaveBytes in StaticVars.CodeCaveBytes)
            {
                if (codeCaveBytes != this)
                {
                    addressOffset += codeCaveBytes.Bytes.Length;
                }
            }
            return StaticVars.CodeCaveAddress + addressOffset;
        }
    }
}
