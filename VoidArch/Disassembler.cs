using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidArch
{
    /// <summary>
    /// C# implementation of the void disassembler
    /// </summary>
    public class Disassembler
    {
        public static string Disassemble(byte[] code)
        {
            string codeStr = "";

            int pos = 0;
            while(pos < code.Length)
            {
                OpCode opcode;
                try
                {
                    opcode = (OpCode)typeof(OpCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Single(f => ((OpCode)f.GetValue(null)).Instruction == code[pos]).GetValue(null);
                }
                catch (Exception)
                {
                    throw new Exception("Invalid op code @" + (pos + 1).ToString());
                }

                codeStr += opcode.Name + " ";
                //Next byte
                pos++;
                
                if(opcode.ArgCount > 0)
                {
                    for(int c = 0;c < opcode.ArgCount; c++)
                    {
                        if(opcode.Name == "mve")
                        {
                            codeStr += BitConverter.ToInt64(code, pos).ToString() + " ";
                        }
                        else
                        {
                            Register arg = (Register)typeof(Register).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Single(f => ((Register)f.GetValue(null)).Id == code[pos]).GetValue(null);
                            codeStr += arg.Name + " ";
                        }
                        pos++;
                    }
                }
                codeStr += ";\n";

            }

            return codeStr;
        }

    }
}
