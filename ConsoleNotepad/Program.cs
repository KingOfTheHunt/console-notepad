using ConsoleNotepad.Excecoes;
using ConsoleNotepad.Telas;
using System;

namespace ConsoleNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.MostraMenu();
            }
            catch (ExcecaoArquivo ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
