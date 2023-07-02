using Newtonsoft.Json.Linq;

namespace RestAPI.TestData
{
    public static class TestingData
    {
        public static JObject TestDataFile => JObject.Parse(File.ReadAllText(@"Resources\testData.json"));

        public static JObject UserDataFile => JObject.Parse(File.ReadAllText(@"Resources\user.json"));

        public static int LengthOfRandomlyGeneratedString => int.Parse(TestDataFile.SelectToken("lengthOfRandomlyGeneratedString").ToString());

        public static int ExpectedPostId => int.Parse(TestDataFile.SelectToken("getPostWithId.expectedPostId").ToString());

        public static int ExpectedPostUserId => int.Parse(TestDataFile.SelectToken("getPostWithId.expectedPostUserId").ToString());

        public static string ExpectedContentType => TestDataFile.SelectToken("expectedContentType").ToString();

        public static string ExistingPost => TestDataFile.SelectToken("getPostWithId.existingPost").ToString();

        public static string NotExistingPost => TestDataFile.SelectToken("getPostNotFoundError.notExistingPost").ToString();

        public static string ExistingUser => TestDataFile.SelectToken("getUserWithId.existingUser").ToString();

        public static string EmptyBody => TestDataFile.SelectToken("getPostNotFoundError.emptyBody").ToString();

        public static string OrderParameter => TestDataFile.SelectToken("getAllPosts.orderParameter").ToString();

        public static int UserIdToCreate => int.Parse(TestDataFile.SelectToken("createPost.userIdToCreate").ToString());

        public static int IdToCreate => int.Parse(TestDataFile.SelectToken("createPost.idToCreate").ToString());
    }
}
