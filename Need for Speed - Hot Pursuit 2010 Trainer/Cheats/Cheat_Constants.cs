namespace Need_for_Speed___Hot_Pursuit_2010_Trainer.Cheats
{
    public static class Cheat_Constants
    {
        public static string FormTitle { get; set; } = "Need for Speed Hot Pursuit 2010 Trainer";
        public static string GameExeName { get; set; } = "NFS11";
        public static uint CodeCaveMinSizeInBytes { get; set; } = 5 * 1024;

        #region Nitro Cheat data
        public const string Nitro_Player_CheatName = "UnlimitedNitroCheat";
        public const string NitroTriggerByte_PlayerVariable = "isPlayerFullNitro";
        public static string NitroAccessorAddress { get; set; } = "\"NFS11.exe\"+1D8DA0";
        public static string NitroAccessorBytes { get; set; } = "F3 0F 10 84 0A F4 C6 03 00";
        public static string NitroJumpBytes { get; set; } = @"
{:NitroJumpAddress} E9 {NitroCaveAddress}
90 90 90 90
{:NitroJumpReturn}";
        public static string NitroCaveBytes { get; set; } = @"
{:NitroCaveAddress} 60
83 BC 11 04 C7 03 00 00
0F 85 {BotNitroCode}
{:PlayerNitroCode} 80 3D {" + NitroTriggerByte_PlayerVariable + @",var} 01
0F 85 {NitroEnd}
C7 84 11 F4 C6 03 00 00 00 C8 42
E9 {NitroEnd}
{:BotNitroCode} 80 3D {" + NitroTriggerByte_BotsVariable + @",var} 01
0F 85 {NitroEnd}
C7 84 11 F4 C6 03 00 00 00 00 00
{:NitroEnd} 61
F3 0F 10 84 11 F4 C6 03 00
E9 {NitroJumpReturn}
{:" + NitroTriggerByte_PlayerVariable + @"} 00
{:" + NitroTriggerByte_BotsVariable + @"} 00";

        #region Bots with no nitro

        public const string Nitro_NoBots_CheatName = "BotsNoNitroCheat";
        public const string NitroTriggerByte_BotsVariable = "isAllOthersWithoutNitro";

        #endregion

        #endregion

        public static string UtilsAccessorAddress { get; set; } = "NFS11.exe+176DA3";
        public static string UtilsAccessorBytes { get; set; } = "83 3C 96 00 0F 8E 48 03 00 00";

        #region HP Cheat data
        public const string HP_Player_CheatName = "UnlimitedHPCheat";
        public const string HPTriggerByte_PlayerVariable = "isPlayerFullHP";
        public static string HPAccessorAddress { get; set; } = "\"NFS11.exe\"+5680D";
        public static string HPAccessorBytes { get; set; } = "0F 28 80 B0 1A 00 00";
        public static string HPJumpBytes { get; set; } = @"
{:HPJumpAddress} E9 {HPCaveAddress}
90 90
{:HPJumpReturn}";
        public static string HPCaveBytes { get; set; } = @"
{:HPCaveAddress} 60
83 B8 E0 1A 00 00 00
0F 84 {BotHPCode}
{:PlayerHPCode} 80 3D {" + HPTriggerByte_PlayerVariable + @",var} 01
0F 85 {HPEnd}
C7 80 B0 1A 00 00 00 00 00 00
E9 {HPEnd}
{:BotHPCode} 80 3D {" + HPTriggerByte_BotVariable + @",var} 01
0F 85 {HPEnd}
C7 80 B0 1A 00 00 00 00 80 3F
{:HPEnd} 61
0F 28 80 B0 1A 00 00
E9 {HPJumpReturn}
{:" + HPTriggerByte_PlayerVariable + @"} 00
{:" + HPTriggerByte_BotVariable + @"} 00";

        #region Takedown Cheat data
        public const string HP_Bot_CheatName = "InstantTakeDownCheat";
        public const string HPTriggerByte_BotVariable = "isInstantTakedown";
        #endregion
        #endregion
    }
}
