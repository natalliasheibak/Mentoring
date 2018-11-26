using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BCL.Configuration
{
    class DirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("folderPath", IsKey = true, IsRequired = true)]
        public string Directory => (string)this["folderPath"];
    }
}
