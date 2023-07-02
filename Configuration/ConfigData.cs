using Newtonsoft.Json.Linq;

namespace RestAPI.Configuration
{
    public static class ConfigData
    {
        public static JObject ConfigDataFile => JObject.Parse(File.ReadAllText(@"Resources\configuration.json"));

        public static string BaseUrl => ConfigDataFile.SelectToken("baseUrl").ToString();

        public static string AllPosts => ConfigDataFile.SelectToken("allPosts").ToString();

        public static string AllUsers => ConfigDataFile.SelectToken("allUsers").ToString();

        public static string PostWithId => ConfigDataFile.SelectToken("postWithId").ToString();

        public static string UserWithId => ConfigDataFile.SelectToken("userWithId").ToString();
    }
}
