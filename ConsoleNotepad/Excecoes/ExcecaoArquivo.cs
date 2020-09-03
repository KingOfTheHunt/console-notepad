using System;

namespace ConsoleNotepad.Excecoes
{
    class ExcecaoArquivo : ApplicationException
    {
        public ExcecaoArquivo(string mensagem) : base(mensagem)
        {
        }
    }
}
