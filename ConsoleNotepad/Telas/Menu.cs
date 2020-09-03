using System;
using ConsoleNotepad.Excecoes;
using ConsoleNotepad.Servicos;

namespace ConsoleNotepad.Telas
{
    class Menu
    {
        public static void MostraMenu()
        {
            Console.Write("Informe o caminho do arquivo: ");
            string caminho = @"" + Console.ReadLine();
           
            do
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Ler um arquivo.");
                Console.WriteLine("2 - Escrever um arquivo.");
                Console.WriteLine("3 - Sair.");
                Console.Write("Informe o que deseja fazer: ");
                char d = Console.ReadLine()[0];

                switch (d)
                {
                    case '1':
                        Leitura(caminho);
                        break;
                    case '2':
                        Escrita(caminho);
                        break;
                    case '3':
                        return;
                    default:
                        break;
                }
            } while (true);
            
        }

        public static void Leitura(string caminho)
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Conteúdo do arquivo:");
                Arquivo arquivo = new Arquivo();
                foreach (string linha in arquivo.Ler(caminho))
                {
                    Console.WriteLine(linha);
                }
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            catch (ExcecaoArquivo ex)
            {
                throw new ExcecaoArquivo($"Erro: {ex.Message}");
            }
        }

        public static void Escrita(string caminho)
        {
            Arquivo arquivo = new Arquivo();
            ConsoleKeyInfo keyInfo;
            Console.Clear();

            try
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Digite o texto: ");
                    string conteudo = Console.ReadLine();
                    arquivo.Escrever(caminho, conteudo);
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para continuar adicionando " +
                        "texto ou X para parar.");
                    keyInfo = Console.ReadKey();
                    Console.WriteLine();
                } while (keyInfo.Key != ConsoleKey.X);
            }
            catch (ExcecaoArquivo ex)
            {
                throw new ExcecaoArquivo(ex.Message);
            }
        } 
    }
}
