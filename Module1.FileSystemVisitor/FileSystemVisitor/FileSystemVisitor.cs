using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class FileSystemVisitor
    {
        private Func<FileSystemInfo, bool> _filterFileFunc = (x) => true;

        private bool _isSearchComplete = false;

        private string _nextFileToSkip;

        public event EventHandler<WorkEventArgs> WorkStarted;

        public event EventHandler<WorkEventArgs> WorkFinished;

        public event EventHandler<FileFoundEventArgs> FileFound;

        public event EventHandler<DirectoryFoundEventArgs> DirectoryFound;

        public event EventHandler<FileFoundEventArgs> FilteredFileFound;

        public event EventHandler<DirectoryFoundEventArgs> FilteredDirectoryFound;

        #region Constructors

        public FileSystemVisitor()
        {
        }

        public FileSystemVisitor(Func<FileSystemInfo, bool> func)
        {
            _filterFileFunc = func;
        }

        #endregion

        public void CompleteSearch()
        {
            _isSearchComplete = true;
        }

        public void SkipFile(string fileName)
        {
            _nextFileToSkip = fileName;
        }

        public IEnumerable<string> GetFileList(string directoryPath)
        {
            OnWorkStarted(this, new WorkEventArgs("Work started."));

            var directoryInfo = new DirectoryInfo(directoryPath);
            foreach (var file in directoryInfo.GetFiles())
            {
                OnFileFound(this, new FileFoundEventArgs("File found.", file.FullName));

                if (_filterFileFunc(file))
                {
                    OnFilteredFileFound(this, new FileFoundEventArgs("Filtered file found.", file.FullName));

                    if (_isSearchComplete)
                    {
                        yield break;
                    }

                    if (file.FullName.Equals(_nextFileToSkip))
                    {
                        continue;
                    }

                    yield return file.FullName;
                }
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                OnDirectoryFound(this, new DirectoryFoundEventArgs("Directory found.", directory.FullName));
                if (_filterFileFunc(directory))
                {
                    OnFilteredDirectoryFound(this, new DirectoryFoundEventArgs("Directory found.", directory.FullName));

                    if (_isSearchComplete)
                    {
                        yield break;
                    }

                    if (directory.FullName.Equals(_nextFileToSkip))
                    {
                        continue;
                    }

                    foreach(var file in GetFileList(directory.FullName))
                    {
                        yield return file;
                    }

                    yield return directory.FullName;
                }
            }

            OnWorkFinished(this, new WorkEventArgs("Work finished."));
        }

        protected virtual void OnWorkStarted(object sender, WorkEventArgs e)
        {
            WorkStarted?.Invoke(sender, e);
        }

        protected virtual void OnWorkFinished(object sender, WorkEventArgs e)
        {
            WorkFinished?.Invoke(sender, e);
        }

        protected virtual void OnFileFound(object sender, FileFoundEventArgs e)
        {
            FileFound?.Invoke(sender, e);
        }

        protected virtual void OnDirectoryFound(object sender, DirectoryFoundEventArgs e)
        {
            DirectoryFound?.Invoke(sender, e);
        }

        protected virtual void OnFilteredFileFound(object sender, FileFoundEventArgs e)
        {
            FilteredFileFound?.Invoke(sender, e);
        }

        protected virtual void OnFilteredDirectoryFound(object sender, DirectoryFoundEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(sender, e);
        }
    }
}
