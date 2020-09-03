using ConsoleNotepad.Excecoes;
using System;
using System.IO;

namespace ConsoleNotepad.Servicos
{
    class Arquivo
    {
        private bool ExisteArquivo(string caminho)
        {
            if (File.Exists(caminho))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna o conteúdo do arquivo em formato de um array de string.
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public string[] Ler(string caminho)
        {
            if (!ExisteArquivo(caminho))
            {
                throw new ExcecaoArquivo("O arquivo informado não existe!");
            }

            string[] linhas = File.ReadAllLines(caminho);
            return linhas;
        }

        /// <summary>
        /// Adiciona o contéudo no final do arquivo. Caso o arquivo não exista no caminho que foi
        /// especificado, ele será criado.
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="conteudo"></param>
        public void Escrever(string caminho, string conteudo)
        {
            try
            {
                if (!ExisteArquivo(caminho))
                {
                    FileStream fs = File.Create(caminho);
                    fs.Close();
                }

                using (StreamWriter sr = File.AppendText(caminho))
                {
                    sr.WriteLine(conteudo);
                    sr.Close();
                }
            }
            catch (IOException ex)
            {
                throw new ExcecaoArquivo(ex.Message);
            }
        }
    }
}
