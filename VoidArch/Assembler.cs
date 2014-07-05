using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    /// <summary>
    /// C# Implementation of the Void Assembler - assembles vasm into an executable
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// The base address of the code
        /// </summary>
        public static uint BaseLoadAddress = DefaultBaseLoadAddress;

        /// <summary>
        /// The default base address of the code = 0x5CA1AB1E
        /// </summary>
        public const uint DefaultBaseLoadAddress = 0x5CA1AB1E;

        /// <summary>
        /// Expands macros and simplifies code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string ExpandAndSimplify(string code)
        {
            //Generate temporary offsets relative to the base load point of the code
        }

        /// <summary>
        /// Compile time optimizer
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string Optimize(string code)
        {
            return code;
        }

        public static byte[] Assemble(string code)
        {
            List<byte> compiled = new List<byte>();

            code = ExpandAndSimplify(code);
            code = Optimize(code);

            //Split using delimiters
            string[] parts = code.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int ln = 0; ln < parts.Length; ln++)
            {

                if (parts[ln].StartsWith(".") | parts[ln].EndsWith(":"))
                {
                    #region Macro and function call translator

                    #endregion
                }
                else
                {
                    #region Opcode translator
                    //Find any opcode which matches the instruction
                    OpCode opcode;
                    try
                    {
                        opcode = (OpCode)typeof(OpCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Single(f => ((OpCode)f.GetValue(null)).Name == parts[ln].Trim().Split(' ')[0].Trim()).GetValue(null);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Invalid op code " + parts[ln] + " @" + (ln + 1).ToString());
                    }

                    //Add the opcode instruction
                    compiled.Add(opcode.Instruction);

                    if (opcode.ArgCount > 0)
                    {
                        if (parts[ln].Split(' ').Length != opcode.ArgCount + 1) throw new Exception("Incorrect number of arguments @ " + (ln + 1).ToString());

                        for (int c = 0; c < opcode.ArgCount; c++)
                        {
                            long num;
                            if (long.TryParse(parts[ln].Split(' ')[c + 1], out num))
                            {
                                if (opcode.Name != "mve") throw new Exception("Invalid Parameter to instruction '" + opcode.Name + "' @ " + (ln + 1).ToString());

                                //MVE is the only instruction which accepts numerical values
                                compiled.AddRange(BitConverter.GetBytes(num));
                            }
                            else
                            {
                                //Add the register id
                                Register arg = (Register)typeof(Register).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Single(f => ((Register)f.GetValue(null)).Name == parts[ln].Trim().Split(' ')[c + 1].Trim()).GetValue(null);
                                compiled.Add(arg.Id);
                            }
                        }
                    }
                    #endregion
                }
            }

            return compiled.ToArray();
        }

    }
}
