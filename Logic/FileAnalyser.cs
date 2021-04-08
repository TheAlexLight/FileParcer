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
    class FileAnalyser: IParcer
    {
        readonly ConsolePrinter _printer = new ConsolePrinter();

        IReplacer stringReplacer = new Replacer();
        IFileManager manager = new FileManager();



        public void Parce(string fileName, string searchInFile, string replaceInFile)
        {
            string tempFileName = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());

            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                bool isEndOfFile = false;
                int skipLines = 0;


                while (!isEndOfFile)
                {
                    List<string> listOfFileLines = manager.ReadLine(filePath, ref skipLines, ref isEndOfFile);

                    listOfFileLines = stringReplacer.ReplaceStrings(listOfFileLines, searchInFile, replaceInFile);

                    manager.AppendLines(listOfFileLines, tempFileName);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.Move(tempFileName, filePath);

               // return countReplacement;
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
                File.Delete(tempFileName);
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
