﻿using System.Runtime.InteropServices;

namespace Memory.Core
{
    internal static class Kernel
    {
        internal static class Imps
        {
            internal static class DesiredAccess
            {
                public static int PROCESS_ALL_ACCESS = 0x1F0FFF;
            }

            internal static class AllocationType
            {
                public static int flAllocationType_MEM_COMMIT = 0;
                public static int flAllocationType_MEM_RESERVE = 0;
            }

            internal static class Protection
            {
                public static int flProtect_PAGE_EXECUTE_READWRITE = 0;
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, Int32 dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool EnumProcessModules(IntPtr hProcess, [Out] IntPtr lphModule, uint cb, [MarshalAs(UnmanagedType.U4)] out uint lpcbNeeded);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern UIntPtr VirtualAllocEx(IntPtr hProcess, UIntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    }
}
