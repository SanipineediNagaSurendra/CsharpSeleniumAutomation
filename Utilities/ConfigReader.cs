using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Automation.Utilities
{
    public static class ConfigReader
    {
        public static IConfigurationRoot Config { get; }

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Config = builder.Build();
        }

        public static string currentAddress => $"{Config["Current Address:D.no"]}, {Config["Current Address:Street"]}, {Config["Current Address:City"]}";

        public static string permanentAddress => $"{Config["Permanent Address:D.no"]}, {Config["Permanent Address:Street"]}, {Config["Permanent Address:Locality"]}";


    }


}
