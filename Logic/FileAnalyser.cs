using _4.FileParcer.Interfaces;
using _4.FileParcer.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksLibrary;

namespace _4.FileParcer.Logic
{
   internal class FileAnalyser: IParcer
    {
        public FileAnalyser(IFileManager manager, IOutsidePrinter printer)
        {
            _manager = manager;
            _printer = printer;
        }

        readonly IFileManager _manager;
        readonly IOutsidePrinter _printer;
       
        public void Parce(IReplacer stringReplacer, string[] args)
        {
            string tempFilePath = null;  

            try
            {
                IReplacer _stringReplacer = stringReplacer;

                string fileName = args[0];
                string searchInFile = args[1];
                string replaceInFile = args[2];

                tempFilePath = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                var writer = _manager.OpenFileForWrite(tempFilePath);

                foreach (var line in _manager.ReadFile(filePath))
                {
                    string newLine = stringReplacer.ReplaceString((string)line, searchInFile, replaceInFile);
                    writer.WriteLine(newLine);
                }

                _manager.Dispose();

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
                _manager.Dispose();

                if (tempFilePath != null)
                {
                    File.Delete(tempFilePath);
                } 
            }
        }

        public int CountOccurrences(string[] args)
        {
            try
            {
                string fileName = args[0];
                string searchInFile = args[1];

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
