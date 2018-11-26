using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_BCL.Configuration;

namespace Task4_BCL
{
    static class ConfigurationHelper
    {
        public static FileConfigurationSection FileConfigurationSection => (FileConfigurationSection)ConfigurationManager.GetSection("directoryInformationSection");

        public static CultureInfo CultureInfo => FileConfigurationSection.Culture;

        public static DirectoryElementCollection Directories => FileConfigurationSection.Directories;

        public static DirectoryPatternElementCollection DirectoryPatterns => FileConfigurationSection.DirectoryPatterns;
    }
}
