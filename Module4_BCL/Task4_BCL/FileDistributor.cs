using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task4_BCL.Configuration;

namespace Task4_BCL
{
    public class FileDistributor
    {
        private Logger logger = new Logger();

        private int number = 0;

        public void DistributeFile(object source, FileSystemEventArgs e)
        {
            var pattern = SearchPattern(e.Name);
            if (pattern == null)
            {
                MoveFileToDefaultFolder(e.FullPath);
            }
            else
            {
                logger.PatternFoundForFile(e.Name, pattern.Name);

                var newName = e.Name;

                if (pattern.AddDate)
                {
                    newName = AppendTextToTheFileName(newName, DateTime.Now.ToString("d", ConfigurationHelper.CultureInfo));
                }

                if (pattern.AddNumber)
                {
                    number++;
                    newName = AppendTextToTheFileName(newName, number.ToString());
                }

                MoveFileToFolder(e.FullPath, pattern.Folder, newName);
            }
        }

        #region private

        private DirectoryPatternElement SearchPattern(string file)
        {
            return ConfigurationHelper.DirectoryPatterns.OfType<DirectoryPatternElement>().FirstOrDefault(x => Regex.IsMatch(file, x.Pattern));
        }

        private void MoveFileToFolder(string fullFileName, string folder, string newName = null)
        {
            var newFileName = newName ?? Path.GetFileName(fullFileName);

            string destFile = Path.Combine(folder, newFileName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                File.Move(fullFileName, destFile);
            }
            catch (Exception e)
            {

                logger.FileMoveError(fullFileName, folder, e);
            }

            logger.FileMoved(fullFileName, folder);
        }

        private void MoveFileToDefaultFolder(string fullFileName)
        {
            MoveFileToFolder(fullFileName, ConfigurationHelper.DirectoryPatterns.DefaultFolder);
        }

        private string AppendTextToTheFileName(string fileName, string textToAppend)
        {
            return Path.GetFileNameWithoutExtension(fileName) + "_" + textToAppend + Path.GetExtension(fileName);
        }

        #endregion
    }
}
