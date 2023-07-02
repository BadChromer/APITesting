using RestAPI.Configuration;
using RestAPI.Models;
using RestSharp;

namespace RestAPI.API
{
    public static class APIMethods
    {
        public static RestClient restClient = new(ConfigData.BaseUrl);

        public static RestResponse<List<PostModel>> GetAllPosts()
        {
            var request = new RestRequest(ConfigData.AllPosts);
            return restClient.Execute<List<PostModel>>(request, Method.Get);
        }

        public static RestResponse<List<UserModel>> GetAllUsers()
        {
            var request = new RestRequest(ConfigData.AllUsers);
            return restClient.Execute<List<UserModel>>(request, Method.Get);
        }

        public static RestResponse<PostModel> GetPostWithId(string id)
        {
            var request = new RestRequest(string.Format(ConfigData.PostWithId, id));
            return restClient.Execute<PostModel>(request, Method.Get);
        }

        public static RestResponse<UserModel> GetUserWithId(string id)
        {
            var request = new RestRequest(string.Format(ConfigData.UserWithId, id));
            return restClient.Execute<UserModel>(request, Method.Get);
        }

        public static RestResponse<PostModel> CreatePost(PostModel newPost)
        {
            var request = new RestRequest(ConfigData.AllPosts);
            return restClient.Execute<PostModel>(request.AddJsonBody(newPost), Method.Post);
        }
    }
}