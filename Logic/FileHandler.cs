using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class FileHandler
    {
        public async Task OpenOrCreate()
        {
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";

            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");

                string str = "o";
                string subStr = "AA";

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() != -1)
                        {
                            string line = sr.ReadLine();

                            if (line.Contains(str))
                            {
                                line = line.Replace(str, subStr);
                            }

                            sw.WriteLine(line);
                        }
                    }
                }

                string str23 = "path to output file.txt";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.Move(fileName, path);

                //File.Replace(str23, path, null);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                File.Delete(fileName);
            }
        }

    }
}
