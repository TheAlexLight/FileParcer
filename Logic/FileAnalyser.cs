using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
       
        public void Replace(IReplacer stringReplacer, string[] args)
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

                var _manager = _managerFactory.CreateFileManager(tempFilePath);
                
                    foreach (var line in _manager.Read(filePath))
                    {
                        string newLine = stringReplacer.ReplaceString(line, searchInFile, replaceInFile);
                        _manager.WriteLine(newLine);
                    }
                

                if (File.Exists(string.Format("{0}.bac", filePath)))
                {
                    File.Delete(string.Format("{0}.bac", filePath));
                }

                File.Move(filePath, string.Format("{0}.bac", filePath));
                File.Move(tempFilePath, filePath);
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

                var manager = _managerFactory.CreateFileManager(null);

                int count = 0;

                foreach (var line in manager.Read(path))
                {
                    count += Regex.Matches(line, searchInFile).Count;
                }

                return count;
            }
            catch (IOException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
        }
    } 
}
