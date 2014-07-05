using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoidArch;

namespace VoidTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine("Void Terminal v" + typeof(Program).Assembly.GetName().Version);
            Console.WriteLine("Void Platform v" + typeof(Assembler).Assembly.GetName().Version);

            while (true)
            {
                Console.Write("\nvoid>");
                string cmd = Console.ReadLine().Trim().ToLowerInvariant();

                string[] @params = cmd.Split(' ');

                if (@params[0] == "ls")
                {
                    #region LS
                    var data = Directory.EnumerateFileSystemEntries((@params.Length > 1) ? @params[1] : Environment.CurrentDirectory);

                    foreach (string entry in data)
                    {
                        if (Directory.Exists(entry))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }

                        Console.WriteLine("\t" + Path.GetFileName(entry));

                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    #endregion
                }
                else if (@params[0] == "cd")
                {
                    #region CD
                    Environment.CurrentDirectory = @params[1];
                    #endregion
                }
                else if (@params[0] == "wdir")
                {
                    #region Wdir
                    Console.WriteLine(Environment.CurrentDirectory);
                    #endregion
                }
                else if (@params[0] == "vasm")
                {
                    #region Void Assembler

                    #endregion
                }
                else if (@params[0] == "vdasm")
                {
                    #region Void Disassembler

                    #endregion
                }
                else if (@params[0] == "void")
                {
                    #region Void VM

                    #endregion
                }
                else if (@params[0] == "mekax")
                {
                    #region MekaX

                    #endregion
                }
                else if(@params[0] == "vlink")
                {
                    #region Void Linker

                    #endregion
                }
                else if (@params[0] == "help" || @params[0] == "?")
                {
                    #region Help

                    Console.WriteLine("\t{0}\t:\t{1}", "ls", "List the directory contents");
                    Console.WriteLine("\t{0}\t:\t{1}", "cd", "Change the current working directory");
                    Console.WriteLine("\t{0}\t:\t{1}", "wdir", "Show the current working directory");
                    Console.WriteLine("\t{0}\t:\t{1}", "vasm", "Invoke the void assembler");
                    Console.WriteLine("\t{0}\t:\t{1}", "vdasm", "Invoke the void disassembler");
                    Console.WriteLine("\t{0}\t:\t{1}", "void", "Invoke the void VM");
                    Console.WriteLine("\t{0}\t:\t{1}", "mekax", "Invoke the MekaX compiler");
                    Console.WriteLine("\t{0}\t:\t{1}", "vlink", "Invoke the void linker");

                    #endregion
                }


            }


        }
    }
}
