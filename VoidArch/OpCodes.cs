using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    public struct OpCode
    {
        public byte Instruction;
        public string Name;
        public byte Size;
        public byte ArgCount;

        public override string ToString()
        {
            return Name;
        }
    }

    public class OpCodes
    {
        /// <summary>
        /// Push a value on to the stack
        /// </summary>
        public static OpCode Push { get; private set; }

        /// <summary>
        /// Pop a value from the stack into a register
        /// </summary>
        public static OpCode Pop { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push (a == b)?1:0
        /// </summary>
        public static OpCode Eq { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push (a &lt; b)?1:0
        /// </summary>
        public static OpCode Lt { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a + b
        /// </summary>
        public static OpCode Add { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a - b
        /// </summary>
        public static OpCode Sub { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a * b
        /// </summary>
        public static OpCode Mul { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a / b
        /// </summary>
        public static OpCode Div { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a & b
        /// </summary>
        public static OpCode And { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a | b
        /// </summary>
        public static OpCode Or { get; private set; }

        /// <summary>
        /// Pop a & b off the stack and push a ^ b
        /// </summary>
        public static OpCode Xor { get; private set; }

        /// <summary>
        /// Pop a off the stack and push !a
        /// </summary>
        public static OpCode Not { get; private set; }

        /// <summary>
        /// Load value into register given the address and length
        /// </summary>
        public static OpCode LLe { get; private set; }

        /// <summary>
        /// Store a value into memory at an address given the register name and length
        /// </summary>
        public static OpCode SLe { get; private set; }

        /// <summary>
        /// Not circular Left shift
        /// </summary>
        public static OpCode LSh { get; private set; }

        /// <summary>
        /// Not circular right shift
        /// </summary>
        public static OpCode RSh { get; private set; }

        /// <summary>
        /// Circular left shift
        /// </summary>
        public static OpCode LRS { get; private set; }

        /// <summary>
        /// Circular right shift
        /// </summary>
        public static OpCode RRS { get; private set; }

        /// <summary>
        /// No Operation instruction
        /// </summary>
        public static OpCode Nop { get; private set; }

        /// <summary>
        /// Store a value into a register
        /// </summary>
        public static OpCode Mve { get; private set; }

        private static byte fromBinInt(uint num)
        {
            return Convert.ToByte(num.ToString(), 2);
        }
        private static byte fromBinInt(string num)
        {
            return Convert.ToByte(num, 2);
        }

        static OpCodes()
        {
            #region Initializers
            Push = new OpCode()
            {
                Name = "push",
                ArgCount = 1,
                Instruction = fromBinInt(00000),
                Size = 5
            };

            Pop = new OpCode()
            {
                Name = "pop",
                ArgCount = 1,
                Instruction = fromBinInt(10000),
                Size = 5
            };

            Eq = new OpCode()
            {
                Name = "eq",
                ArgCount = 0,
                Instruction = fromBinInt(11000),
                Size = 5
            };

            Lt = new OpCode()
            {
                Name = "lt",
                ArgCount = 0,
                Instruction = fromBinInt(11100),
                Size = 5
            };

            Add = new OpCode()
            {
                Name = "add",
                ArgCount = 0,
                Instruction = fromBinInt(11110),
                Size = 5
            };

            Sub = new OpCode()
            {
                Name = "sub",
                ArgCount = 0,
                Instruction = fromBinInt(11111),
                Size = 5
            };

            Mul = new OpCode()
            {
                Name = "mul",
                ArgCount = 0,
                Instruction = fromBinInt("01111"),
                Size = 5
            };

            Div = new OpCode()
            {
                Name = "div",
                ArgCount = 0,
                Instruction = fromBinInt("00111"),
                Size = 5
            };

            And = new OpCode()
            {
                Name = "and",
                ArgCount = 0,
                Instruction = fromBinInt("00011"),
                Size = 5
            };

            Or = new OpCode()
            {
                Name = "or",
                ArgCount = 0,
                Instruction = fromBinInt("00001"),
                Size = 5
            };

            Xor = new OpCode()
            {
                Name = "xor",
                ArgCount = 0,
                Instruction = fromBinInt("00010"),
                Size = 5
            };

            Not = new OpCode()
            {
                Name = "not",
                ArgCount = 0,
                Instruction = fromBinInt("00100"),
                Size = 5
            };

            LLe = new OpCode()
            {
                Name = "lle",
                ArgCount = 1,
                Instruction = fromBinInt("01000"),
                Size = 5
            };

            SLe = new OpCode()
            {
                Name = "sle",
                ArgCount = 1,
                Instruction = fromBinInt("11000"),
                Size = 5
            };

            LSh = new OpCode()
            {
                Name = "lsh",
                ArgCount = 1,
                Instruction = fromBinInt("01100"),
                Size = 5
            };

            RSh = new OpCode()
            {
                Name = "rsh",
                ArgCount = 1,
                Instruction = fromBinInt("00110"),
                Size = 5
            };

            LRS = new OpCode()
            {
                Name = "lrs",
                ArgCount = 1,
                Instruction = fromBinInt("01110"),
                Size = 5
            };

            RRS = new OpCode()
            {
                Name = "rrs",
                ArgCount = 1,
                Instruction = fromBinInt("00111"),
                Size = 5
            };

            Nop = new OpCode()
            {
                Name = "nop",
                ArgCount = 0,
                Instruction = fromBinInt("01111"),
                Size = 5
            };

            Mve = new OpCode()
            {
                Name = "mve",
                ArgCount = 2,
                Instruction = fromBinInt("01010"),
                Size = 5
            };
            #endregion
        }

    }
}
