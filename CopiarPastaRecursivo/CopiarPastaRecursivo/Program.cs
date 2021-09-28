using System;
using System.IO;
using System.Threading;

namespace CopiarPastaRecursivo
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
                var pasta1 = Path.Combine(Environment.CurrentDirectory, "Pasta1");
                var pasta1Destino = Path.Combine(Environment.CurrentDirectory, "Pasta1Destino");

                if (Directory.Exists(pasta1))
                {
                    Directory.Delete(pasta1, true);
                }

                if (Directory.Exists(pasta1Destino))
                {
                    Directory.Delete(pasta1Destino, true);
                }

                Directory.CreateDirectory(pasta1);

                var pastaInterna1 = Path.Combine(pasta1, "PastaInterna1");
                var pastaInterna2 = Path.Combine(pasta1, "PastaInterna2");
                var pastaInterna3 = Path.Combine(pasta1, "PastaInterna3");

                Directory.CreateDirectory(pastaInterna1);
                Directory.CreateDirectory(pastaInterna2);
                Directory.CreateDirectory(pastaInterna3);

                var arquivo1 = Path.Combine(pastaInterna1, "arquivo1.txt");
                var arquivo2 = Path.Combine(pastaInterna2, "arquivo2.txt");
                var arquivo3 = Path.Combine(pastaInterna3, "arquivo2.txt");

                File.Create(arquivo1);
                File.Create(arquivo2);
                File.Create(arquivo3);

                Thread.Sleep(TimeSpan.FromMinutes(1));

                CopiarPasta(pasta1, pasta1Destino);

                Console.WriteLine("Arquivos copiados com sucesso!");
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
			}

            Console.ReadKey();
        }

        private static void CopiarPasta(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }

                string[] files = Directory.GetFiles(sourceFolder);

                foreach (string file in files)
                {
                    try
                    {
                        string name = Path.GetFileName(file);
                        string dest = Path.Combine(destFolder, name);
                        File.Copy(file, dest, true);
                    }
                    catch (Exception ex1)
                    {

                    }
                }

                string[] folders = Directory.GetDirectories(sourceFolder);

                foreach (string folder in folders)
                {
                    try
                    {
                        string name = Path.GetFileName(folder);
                        string dest = Path.Combine(destFolder, name);
                        CopiarPasta(folder, dest);
                    }
                    catch (Exception ex2)
                    {

                    }
                }
            }
            catch (Exception ex3)
            {

            }
        }
    }
}
