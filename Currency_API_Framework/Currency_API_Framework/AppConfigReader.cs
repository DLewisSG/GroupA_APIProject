using System;
using System.Configuration;

namespace Currency_API_Framework
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
    }
}
