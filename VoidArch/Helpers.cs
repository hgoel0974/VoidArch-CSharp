using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    public static class Helpers
    {
        public static byte[] GetBytes(this int num)
        {
            return BitConverter.GetBytes(
                                    (BitConverter.IsLittleEndian) ? num : System.Net.IPAddress.HostToNetworkOrder(num)
                                    );
        }

        public static byte[] GetBytes(this long num)
        {
            return BitConverter.GetBytes(
                                    (BitConverter.IsLittleEndian) ? num : System.Net.IPAddress.HostToNetworkOrder(num)
                                    );
        }
    }
}
