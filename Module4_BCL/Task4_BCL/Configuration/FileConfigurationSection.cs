using System.Configuration;
using System.Globalization;

namespace Task4_BCL.Configuration
{
    class FileConfigurationSection : ConfigurationSection
    {
        [ConfigurationCollection(typeof(DirectoryElement), AddItemName = "directory")]
        [ConfigurationProperty("directories")]
        public DirectoryElementCollection Directories => (DirectoryElementCollection)this["directories"];

        [ConfigurationCollection(typeof(DirectoryPatternElement), AddItemName = "pattern")]
        [ConfigurationProperty("directoryPatterns")]
        public DirectoryPatternElementCollection DirectoryPatterns => (DirectoryPatternElementCollection)this["directoryPatterns"];

        [ConfigurationProperty("culture", IsRequired = false, DefaultValue = "en-EN")]
        public CultureInfo Culture => new CultureInfo(this["culture"].ToString());
    }
}
