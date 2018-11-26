using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BCL.Configuration
{
    class DirectoryPatternElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name => (string)this["name"];

        [ConfigurationProperty("pattern", IsRequired = true)]
        public string Pattern => (string)this["pattern"];

        [ConfigurationProperty("folder", IsRequired = true)]
        public string Folder => (string)this["folder"];

        [ConfigurationProperty("addDate", IsRequired = false, DefaultValue = false)]
        public bool AddDate => (bool)this["addDate"];

        [ConfigurationProperty("addNumber", IsRequired = false, DefaultValue = false)]
        public bool AddNumber => (bool)this["addNumber"];
    }
}
