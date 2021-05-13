using System;

namespace DigitalMenu.Core.Constants
{
    public class CustomEnvironment
    {
        public static string ApiUrl => Environment.GetEnvironmentVariable("API_URL");
        public static string ClientAppUrl => Environment.GetEnvironmentVariable("CLIENT_APP_URL");
    }
}