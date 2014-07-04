using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    /// <summary>
    /// C# Implementation of the Void Assembler
    /// </summary>
    public class Assembler
    {
        public static byte[] Assemble(string code)
        {
            List<byte> compiled = new List<byte>();

            //Split using delimiters
            string[] parts = code.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int ln = 0; ln < parts.Length; ln++)
            {
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
            }

            return compiled.ToArray();
        }

    }
}
