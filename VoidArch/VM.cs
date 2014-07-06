using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    /// <summary>
    /// C# test implementation of the Void Virtual Machine
    /// </summary>
    public class VM
    {
        public static byte[] Memory;
        public static long MemoryAmount = 48 * 1024 * 1024;

        static VM()
        {
            Memory = new byte[MemoryAmount];
        }

        public static void Run(byte[] code)
        {

        }


    }
}
