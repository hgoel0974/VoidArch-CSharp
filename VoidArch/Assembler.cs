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
        /// The default base address of the code = 0x0
        /// </summary>
        public const uint DefaultBaseLoadAddress = 0x0;

        /// <summary>
        /// Expands macros and simplifies code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string ExpandAndSimplify(string code)
        {
            //Generate temporary offsets relative to the base load point of the code
            string[] parts = code.Split(';', ':');
            List<uint> offsets = new List<uint>();

            Dictionary<string, int> FunctionTable = new Dictionary<string, int>();

            for (int c = 0; c < parts.Length; c++)
            {
                if (parts[c].StartsWith("func "))
                {
                    FunctionTable[parts[c].Replace("func ", string.Empty).Trim()] = c;
                    parts[c] = "nop";   //All function declarations are swapped out for nops
                }
                if (parts[c] != string.Empty) parts[c] = parts[c].Trim();
            }

            string output = "";

            for (int c = 0; c < parts.Length; c++)
            {
                if(parts[c] != string.Empty)output += parts[c].ToLowerInvariant() + ";\n";
            }

            output = output.Remove(output.Length - 1);

            return output;
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

                if (parts[ln].StartsWith("."))
                {
                    #region Macro translator

                    #endregion
                }
                else
                {
                    #region Opcode translator
                    //Find any opcode which matches the instruction
                    OpCode opcode;
                    try
                    {
                        opcode = (OpCode)typeof(OpCodes).GetProperties().Single(f => ((OpCode)f.GetValue(null)).Name == parts[ln].Trim().Split(' ')[0].Trim()).GetValue(null);
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
                                Register arg = (Register)typeof(Registers).GetFields().Single(f =>
                                {
                                    if (f.GetValue(null).GetType().Name.Contains("Byte")) return false;
                                    return ((Register)f.GetValue(null)).Name == parts[ln].Trim().Split(' ')[c + 1].Trim();
                                }).GetValue(null);
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
