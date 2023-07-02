using Newtonsoft.Json.Linq;
using RestAPI.API;
using RestAPI.Models;
using RestAPI.TestData;
using RestAPI.Utilities;
using System.Net;

namespace RestAPI.Tests
{
    public class Tests
    {
        [Test]
        public void GetAllPosts()
        {
            var response = APIMethods.GetAllPosts();
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.ContentType, Is.EqualTo(TestingData.ExpectedContentType));
                Assert.That(response.Data, Is.Ordered.By(TestingData.OrderParameter));
            });
        }

        [Test]
        public void GetPostWithId()
        {
            var response = APIMethods.GetPostWithId(TestingData.ExistingPost);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Data.UserId, Is.EqualTo(TestingData.ExpectedPostUserId));
                Assert.That(response.Data.Id, Is.EqualTo(TestingData.ExpectedPostId));
                Assert.That(response.Data.Title, Is.Not.Null);
                Assert.That(response.Data.Body, Is.Not.Null);
            });
        }

        [Test]
        public void GetPostNotFoundError()
        {
            var response = APIMethods.GetPostWithId(TestingData.NotExistingPost);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(response.Content, Is.EqualTo(TestingData.EmptyBody));
            });
        }

        [Test]
        public void CreatePost()
        {
            var title = RandomGenerator.GenerateRandomString(TestingData.LengthOfRandomlyGeneratedString);
            var body = RandomGenerator.GenerateRandomString(TestingData.LengthOfRandomlyGeneratedString);
            var newPost = new PostModel(TestingData.UserIdToCreate, title, body);
            var response = APIMethods.CreatePost(newPost);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
                Assert.That(response.Data.UserId, Is.EqualTo(TestingData.UserIdToCreate));
                Assert.That(response.Data.Id, Is.EqualTo(TestingData.IdToCreate));
                Assert.That(response.Data.Title, Is.EqualTo(title));
                Assert.That(response.Data.Body, Is.EqualTo(body));
            });
        }

        [Test]
        public void GetAllUsers()
        {
            var response = APIMethods.GetAllUsers();
            var responseById = APIMethods.GetUserWithId(TestingData.ExistingUser);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.ContentType, Is.EqualTo(TestingData.ExpectedContentType));
                Assert.That(response.Data, Contains.Item(responseById.Data));
            });
        }

        [Test]
        public void GetUserWithId()
        {
            var responseById = APIMethods.GetUserWithId(TestingData.ExistingUser);
            Console.WriteLine();
            Assert.Multiple(() =>
            {
                Assert.That(responseById.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(JToken.DeepEquals(TestingData.UserDataFile, JObject.Parse(responseById.Content)), Is.True);
            });
        }
    }
}