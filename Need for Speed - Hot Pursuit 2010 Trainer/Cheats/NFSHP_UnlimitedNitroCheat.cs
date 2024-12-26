using Memory;
using Memory.Core;
using Memory.Core.Models.Cheats;

namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    internal class NFSHP_UnlimitedNitroCheat : CodeInjectionCheat
    {
        private Memory.Memory? memory;
        private uint jumpFromThisAddress;

        public NFSHP_UnlimitedNitroCheat() { }

        public override bool ApplyCheat()
        {
            if (memory == null || memory.Process == null || memory.Process.HasExited)
            {
                return false;
            }

            var isPlayerFullNitro_Address = StaticVars.GetLabelAddress(Cheat_Constants.NitroTriggerByte_PlayerVariable);
            if (isPlayerFullNitro_Address == null)
            {
                return false;
            }

            this.IsEnabled = !this.IsEnabled;

            Kernel.WriteProcessMemory(
                memory.ProcessHandle,
                isPlayerFullNitro_Address.Value,
                this.IsEnabled ? [1] : [0],
                1,
                out _
            );

            return this.IsEnabled;
        }

        public override void Dispose()
        {
            if (memory == null || memory.Process == null || memory.Process.HasExited)
            {
                return;
            }

            var nitroOriginalBytes = Cheat_Constants.NitroAccessorBytes.Replace(" ", "").Replace(Environment.NewLine, "").Trim();

            Kernel.WriteProcessMemory(
                memory.ProcessHandle,
                this.jumpFromThisAddress,
                AddressUtils.HexStringToByteArray(nitroOriginalBytes),
                (UInt32)nitroOriginalBytes.Length / 2,
                out int bytesWritten
            );
        }

        public override bool InitializeCheat(Memory.Memory memory)
        {
            this.memory = memory;
            try
            {
                var targetToJumpFrom_Address = AddressUtils.AddressStringToNumber(Cheat_Constants.NitroAccessorAddress, memory.Process);
                if (targetToJumpFrom_Address == null)
                {
                    throw new Exception($"[{this.Name}] : Unable to get target jump address");
                }

                this.jumpFromThisAddress = targetToJumpFrom_Address.Value;
                var codeCaveAddress = StaticVars.CodeCaveAddress.Value + StaticVars.CodeCaveUsedBytes;

                var jumpBytes = AddressUtils.ParseAsm_CreateLabels(jumpFromThisAddress, Cheat_Constants.NitroJumpBytes);
                var caveBytes = AddressUtils.ParseAsm_CreateLabels(codeCaveAddress, Cheat_Constants.NitroCaveBytes);

                jumpBytes = AddressUtils.ParseAsm_AssignLabels(jumpFromThisAddress, jumpBytes);
                caveBytes = AddressUtils.ParseAsm_AssignLabels(codeCaveAddress, caveBytes);

                Kernel.WriteProcessMemory(
                    memory.ProcessHandle,
                    codeCaveAddress,
                    AddressUtils.HexStringToByteArray(caveBytes),
                    (UInt32)caveBytes.Length / 2,
                    out int bytesWritten
                );

                Kernel.WriteProcessMemory(
                    memory.ProcessHandle,
                    jumpFromThisAddress,
                    AddressUtils.HexStringToByteArray(jumpBytes),
                    (UInt32)jumpBytes.Length / 2,
                    out bytesWritten
                );

                StaticVars.CodeCaveUsedBytes += (uint)(caveBytes.Length / 2);

                this.IsInitialized = true;
            }
            catch { }
            return this.IsInitialized;
        }
    }
}
