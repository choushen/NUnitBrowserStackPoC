using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace NUnitBrowserStackPoC.Utilities
{
    public class BrowserStackConfigManager
    {

        public string userName { get; set; }
        public string accessKey { get; set; }
        public string app { get; set; }
        public Platform[] platforms { get; set; }
        public bool browserstackLocal { get; set; }
        public string buildName { get; set; }
        public string projectName { get; set; }
        public bool debug { get; set; }
        public bool networkLogs { get; set; }


        public class Platform
        {
            public string platformName { get; set; }
            public string deviceName { get; set; }
            public string platformVersion { get; set; }
            public string environment { get; set; }
        }


        public BrowserStackConfigManager Load(string path)
        {
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();

            using (var reader = new StreamReader(path))
            {
                return deserializer.Deserialize<BrowserStackConfigManager>(reader);
            }

        }


    }
}
