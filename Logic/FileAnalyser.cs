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
       private readonly ConsolePrinter _printer = new ConsolePrinter();

        public int ParceFile(string fileName, string searchInFile, string replaceInFile)
        {
            string tempFileName = string.Format("{0}{1}.txt", Path.GetTempPath(), Guid.NewGuid().ToString());

            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                int countReplacement = 0;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    List<string> listOfReplacedLines = new List<string>();        

                    while (reader.Peek() != -1)
                    {
                        string lineFromFile = ReplaceOneLine(reader, searchInFile,replaceInFile,ref countReplacement);

                        listOfReplacedLines = AppendLinesIntoAFile(listOfReplacedLines, lineFromFile, tempFileName);
                    }

                    File.AppendAllLines(tempFileName, listOfReplacedLines);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.Move(tempFileName, filePath);

                return countReplacement;
            }
            catch (FileNotFoundException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED,ex.Message));
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

        private string ReplaceOneLine(StreamReader reader, string searchInFile, string replaceInFile, ref int countReplacement)
        {
            string lineFromFile = reader.ReadLine();

            if (lineFromFile.Contains(searchInFile))
            {
                lineFromFile = lineFromFile.Replace(searchInFile, replaceInFile);
                countReplacement++;
            }

            return lineFromFile;
        }

        private List<string> AppendLinesIntoAFile(List<string> listOfReplacedLines, string lineFromFile, string tempFileName)
        {
            listOfReplacedLines.Add(lineFromFile);

            if (listOfReplacedLines.Count == 10000)
            {
                File.AppendAllLines(tempFileName, listOfReplacedLines);
                listOfReplacedLines.Clear();
            }

            return listOfReplacedLines;
        }

        public int CountOccurrencesInFile(string fileName, string searchInFile)
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
