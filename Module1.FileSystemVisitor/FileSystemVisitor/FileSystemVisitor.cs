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
        private Func<FileSystemInfo, bool> _func;

        private bool _isSearchComplete = false;

        private string _nextFileToSkip;

        public event EventHandler<WorkEventArgs> WorkStarted;

        public event EventHandler<WorkEventArgs> WorkFinished;

        public event EventHandler<FileFoundEventArgs> FileFound;

        public event EventHandler<FileFoundEventArgs> DirectoryFound;

        public event EventHandler<FileFoundEventArgs> FilteredFileFound;

        public event EventHandler<FileFoundEventArgs> FilteredDirectoryFound;

        #region Constructors

        public FileSystemVisitor()
        {
            _func = (x) => true;
        }

        public FileSystemVisitor(Func<FileSystemInfo, bool> func)
        {
            _func = func;
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

                if (_func(file))
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
                OnDirectoryFound(this, new FileFoundEventArgs("Directory found.", directory.FullName));
                if (_func(directory))
                {
                    OnFilteredDirectoryFound(this, new FileFoundEventArgs("Directory found.", directory.FullName));

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
            if(WorkStarted != null)
            {
                WorkStarted(this, e);
            }
        }

        protected virtual void OnWorkFinished(object sender, WorkEventArgs e)
        {
            if (WorkFinished != null)
            {
                WorkFinished(this, e);
            }
        }

        protected virtual void OnFileFound(object sender, FileFoundEventArgs e)
        {
            if (FileFound != null)
            {
                FileFound(this, e);
            }
        }

        protected virtual void OnDirectoryFound(object sender, FileFoundEventArgs e)
        {
            if (DirectoryFound != null)
            {
                DirectoryFound(this, e);
            }
        }

        protected virtual void OnFilteredFileFound(object sender, FileFoundEventArgs e)
        {
            if (FilteredFileFound != null)
            {
                FilteredFileFound(this, e);
            }
        }

        protected virtual void OnFilteredDirectoryFound(object sender, FileFoundEventArgs e)
        {
            if (FilteredDirectoryFound != null)
            {
                FilteredDirectoryFound(this, e);
            }
        }
    }

    public class WorkEventArgs : EventArgs
    {
        public readonly string Message;

        public WorkEventArgs(string message)
        {
            Message = message;
        }
    }

    public class FileFoundEventArgs : WorkEventArgs
    {
        public readonly string FileName;

        public FileFoundEventArgs(string message, string fileName)
            :base(message)
        {
            FileName = fileName;
        }
    }
}
