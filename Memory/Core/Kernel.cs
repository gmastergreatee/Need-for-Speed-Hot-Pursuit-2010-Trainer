using System.Runtime.InteropServices;

namespace Memory.Core
{
    internal static class Kernel
    {
        internal static class Imps
        {
            internal static class DW_DesiredAccess
            {
                public static uint PROCESS_ALL_ACCESS = 0x1F0FFF;
            }

            internal static class FL_AllocationType
            {
                public static uint MEM_COMMIT = 0x00001000;
                public static uint MEM_RESERVE = 0x00002000;
            }

            internal static class FL_Protection
            {
                public static uint PAGE_EXECUTE_READWRITE = 0x40;
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, Int32 dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesWritten);

        /// <summary>
        /// <para>Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process.</para>
        /// <para>The function initializes the memory it allocates to zero.</para>
        /// </summary>
        /// <param name="hProcess">
        /// <para>The handle to a process. The function allocates memory within the virtual address space of this process.</para>
        /// <para>The handle must have the PROCESS_VM_OPERATION access right.</para>
        /// </param>
        /// <param name="lpAddress">
        /// <para>The pointer that specifies a desired starting address for the region of pages that you want to allocate.</para>
        /// <para>If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.</para>
        /// <para>If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary.</para>
        /// <para>If lpAddress is NULL, the function determines where to allocate the region.</para>
        /// </param>
        /// <param name="dwSize">
        /// <para>The size of the region of memory to allocate, in bytes.</para>
        /// <para>If lpAddress is NULL, the function rounds dwSize up to the next page boundary.</para>
        /// <para>If lpAddress is not NULL, the function allocates all pages that contain one or more bytes in the range from lpAddress to lpAddress+dwSize. This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.</para>
        /// </param>
        /// <param name="flAllocationType">The type of memory allocation. See <see cref="https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualallocex"/></param>
        /// <param name="flProtect">
        /// The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the <see cref="https://learn.microsoft.com/en-us/windows/win32/Memory/memory-protection-constants">memory protection constants</see>.
        /// </param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern UInt32 VirtualAllocEx(IntPtr hProcess, UIntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    }
}
