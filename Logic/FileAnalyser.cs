using _4.FileParcer.Interfaces;
using _4.FileParcer.View;
using ConsoleTaskLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
   internal class FileAnalyser: IParcer
    {
        readonly ConsolePrinter _printer = new ConsolePrinter();

        public void Parce(string fileName, string searchInFile, string replaceInFile)
        {
            string tempFilePath = null; 

             FileManager manager = new FileManager();

            try
            {
                tempFilePath = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

               // FileReader reader = new FileReader(filePath);

                IReplacer stringReplacer = new Replacer();

                var writer = manager.OpenFileForWrite(tempFilePath);

                foreach (var line in manager.ReadFile(filePath))
                {
                    string newLine = stringReplacer.ReplaceString((string)line, searchInFile, replaceInFile);
                    writer.WriteLine(newLine);
                }

                manager.Dispose();

                string tempName = string.Format("{0} - temp.txt",filePath);

                if (File.Exists(tempName))
                {
                    File.Delete(tempName);
                }

                File.Move(tempFilePath, tempName);
                File.Replace(tempName, filePath, string.Format("{0}.bac", filePath));
            }
            catch (FileNotFoundException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (IOException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            finally
            {
                manager.Dispose();

                if (tempFilePath != null)
                {
                    File.Delete(tempFilePath);
                } 
            }
        }

        public int CountOccurrences(string fileName, string searchInFile)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                return File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), fileName))
                       .Where(l => l.Contains(searchInFile)).Count();
            }
            catch (FileNotFoundException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (IOException ex) 
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
        }
    } 
}
