using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class FileAnalyser
    {
        public int ParceFile(string fileName, string searchInFile, string replaceInFile)
        {
            string tempFileName = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());
            int count = 0;

            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                using (StreamReader sr = new StreamReader(path))
                {
                    List<string> list = new List<string>();
                    //List<string> list2 = new List<string>();

                    //list2 = File.ReadLines(Path.Combine);

                   

                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();

                        if (line.Contains(searchInFile))
                        {
                            line = line.Replace(searchInFile, replaceInFile);
                            count++;
                        }

                        list.Add(line);

                        if (list.Count == 10000)
                        {
                            File.AppendAllLines(tempFileName, list);
                            list.Clear();
                        }
                    }

                    File.AppendAllLines(tempFileName, list);
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.Move(tempFileName, path);

                return count;
            }
            catch (Exception) //ToDO:
            {

                throw;
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }

        public int CountOccurrencesInFile(string fileName, string searchInFile)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            return File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), fileName))
                   .Where(l => l.Contains(searchInFile)).Count();
        }
    } 
}
