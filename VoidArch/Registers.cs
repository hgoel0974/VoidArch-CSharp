using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    public struct Register
    {
        public string Name;
        public byte Id;
        public byte[] Data;
        public uint Length
        {
            get
            {
                return (uint)Data.Length;
            }
            set
            {
                byte[] tmp = new byte[value];
                Data.CopyTo(tmp, 0);
                Data = tmp;
            }
        }
    }

    public enum RegisterTypes : byte
    {
        SInt = 0, UInt = 1, 
        SShort = 2, UShort = 3, 
        SFloat = 4, UFloat = 5, 
        SByte = 6, UByte = 7 
    }

    public static class Registers
    {
        public static byte[] DefaultValue = BitConverter.GetBytes(0xDEADBEEF);

        private static byte[] GetBArray(RegisterTypes t)
        {
            return new byte[] { (byte)t };
        }

        /// <summary>
        /// Program Counter
        /// </summary>
        public static Register PC;

        /// <summary>
        /// Return Address
        /// </summary>
        public static Register RA;

        /// <summary>
        /// General Register 0
        /// </summary>
        public static Register G0;
        
        /// <summary>
        /// General Register 1
        /// </summary>
        public static Register G1;

        /// <summary>
        /// General Register 2
        /// </summary>
        public static Register G2;

        /// <summary>
        /// General Register 3
        /// </summary>
        public static Register G3;

        /// <summary>
        /// General Register 4
        /// </summary>
        public static Register G4;

        /// <summary>
        /// General type Register 0
        /// </summary>
        public static Register Gt0;

        /// <summary>
        /// General type Register 1
        /// </summary>
        public static Register Gt1;

        /// <summary>
        /// General type Register 2
        /// </summary>
        public static Register Gt2;

        /// <summary>
        /// General type Register 3
        /// </summary>
        public static Register Gt3;

        /// <summary>
        /// General type Register 4
        /// </summary>
        public static Register Gt4;

        /// <summary>
        /// Argument Register 0
        /// </summary>
        public static Register A0;

        /// <summary>
        /// Argument Register 1
        /// </summary>
        public static Register A1;

        /// <summary>
        /// Argument Register 2
        /// </summary>
        public static Register A2;

        /// <summary>
        /// Argument Register 3
        /// </summary>
        public static Register A3;
        
        /// <summary>
        /// Argument Register 4
        /// </summary>
        public static Register A4;

        /// <summary>
        /// Argument type Register 0
        /// </summary>
        public static Register At0;

        /// <summary>
        /// Argument type Register 1
        /// </summary>
        public static Register At1;

        /// <summary>
        /// Argument type Register 2
        /// </summary>
        public static Register At2;

        /// <summary>
        /// Argument type Register 3
        /// </summary>
        public static Register At3;

        /// <summary>
        /// Argument type Register 4
        /// </summary>
        public static Register At4;

        static Registers()
        {
            #region Special Registers
            PC = new Register()
            {
                Name = "pc",
                Id = 0,
                Length = 4,
                Data = DefaultValue
            };

            RA = new Register()
            {
                Name = "ra",
                Id = 1,
                Length = 4,
                Data = DefaultValue
            };
            #endregion

            #region General Registers
            G0 = new Register()
            {
                Name = "g0",
                Id = 2,
                Length = 4,
                Data = DefaultValue
            };

            G1 = new Register()
            {
                Name = "g1",
                Id = 3,
                Length = 4,
                Data = DefaultValue
            };

            G2 = new Register()
            {
                Name = "g2",
                Id = 4,
                Length = 4,
                Data = DefaultValue
            };

            G3 = new Register()
            {
                Name = "g3",
                Id = 5,
                Length = 4,
                Data = DefaultValue
            };

            G4 = new Register()
            {
                Name = "g4",
                Id = 6,
                Length = 4,
                Data = DefaultValue
            };
            #endregion

            #region General Register Types
            Gt0 = new Register()
            {
                Name = "gt0",
                Id = 7,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            Gt1 = new Register()
            {
                Name = "gt1",
                Id = 8,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            Gt2 = new Register()
            {
                Name = "gt2",
                Id = 9,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            Gt3 = new Register()
            {
                Name = "gt3",
                Id = 10,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            Gt4 = new Register()
            {
                Name = "gt4",
                Id = 11,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };
            #endregion

            #region Argument Registers
            A0 = new Register()
            {
                Name = "g0",
                Id = 12,
                Length = 4,
                Data = DefaultValue
            };

            A1 = new Register()
            {
                Name = "g1",
                Id = 13,
                Length = 4,
                Data = DefaultValue
            };

            A2 = new Register()
            {
                Name = "g2",
                Id = 14,
                Length = 4,
                Data = DefaultValue
            };

            A3 = new Register()
            {
                Name = "g3",
                Id = 15,
                Length = 4,
                Data = DefaultValue
            };

            A4 = new Register()
            {
                Name = "g4",
                Id = 16,
                Length = 4,
                Data = DefaultValue
            };
            #endregion

            #region Argument Register Types
            At0 = new Register()
            {
                Name = "gt0",
                Id = 17,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            At1 = new Register()
            {
                Name = "gt1",
                Id = 18,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            At2 = new Register()
            {
                Name = "gt2",
                Id = 19,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            At3 = new Register()
            {
                Name = "gt3",
                Id = 20,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };

            At4 = new Register()
            {
                Name = "gt4",
                Id = 21,
                Length = 1,
                Data = GetBArray(RegisterTypes.UInt)
            };
            #endregion
        }


    }
}
