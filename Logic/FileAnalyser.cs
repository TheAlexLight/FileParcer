using System;
using System.IO;
using System.Linq;
using _4.FileParcer.Enums;
using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.View;
using TasksLibrary;

namespace _4.FileParcer.Logic
{
    internal class FileAnalyser: IParcer
    {
        public FileAnalyser(IParcerFactory managerFactory, IOutsidePrinter printer)
        {
            _managerFactory = managerFactory;
            _printer = printer;
        }

        readonly IParcerFactory _managerFactory;
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

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                tempFilePath = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());

                using (var _manager = _managerFactory.CreateFileManager(tempFilePath))
                {
                    foreach (var line in _manager.Read(filePath))
                    {
                        string newLine = stringReplacer.ReplaceString(line, searchInFile, replaceInFile);
                        _manager.WriteLine(newLine);
                    }
                }


                if (File.Exists(string.Format("{0}.bac", filePath)))
                {
                    File.Delete(string.Format("{0}.bac", filePath));
                }

                File.Move(filePath, string.Format("{0}.bac", filePath));
                File.Move(tempFilePath, filePath);


                //string tempName = string.Format("{0} - temp.txt",filePath);

                //if (File.Exists(tempName))
                //{
                //    File.Delete(tempName);
                //}


                //File.Move(tempFilePath, tempName);
                //File.Replace(tempName, filePath, null/*string.Format("{0}.bac", filePath)*/);
            }
            catch (FileNotFoundException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            catch (IOException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            finally
            {
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
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            catch (IOException ex) 
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
        }
    } 
}
