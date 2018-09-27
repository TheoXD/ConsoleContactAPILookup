using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleContactAPI
{
    public static class DefaultConfig
    {
        public const string APIKey = "";
    }

    //Singleton
    public class Config
    {
        private static Config instance;
        private Config() { }

        public string APIKey = "";

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }
    }

}
