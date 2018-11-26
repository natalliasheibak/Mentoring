using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BCL
{
    class Watcher
    {
        private string folder;

        private FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        public Watcher(string folder)
        {
            this.folder = folder;
        }

        public void StartWatch()
        {
            fileSystemWatcher.Path = folder;

            fileSystemWatcher.Created += new FileSystemEventHandler(new Logger().NewFileAddedToFolder);
            fileSystemWatcher.Created += new FileSystemEventHandler(new FileDistributor().DistributeFile);

            fileSystemWatcher.EnableRaisingEvents = true;
        }
    }
}
