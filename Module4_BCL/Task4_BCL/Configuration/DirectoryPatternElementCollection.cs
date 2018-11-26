using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BCL.Configuration
{
    class DirectoryPatternElementCollection : ConfigurationElementCollection
    {
        [ConfigurationProperty("defaultFolder", IsRequired = true)]
        public string DefaultFolder => (string)this["defaultFolder"];

        protected override ConfigurationElement CreateNewElement()
        {
            return new DirectoryPatternElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DirectoryPatternElement)element).Name;
        }
    }
}
