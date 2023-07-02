namespace RestAPI.Models
{
    public class PostModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public PostModel(int UserId, string Title, string Body)
        {
            this.UserId = UserId;
            this.Title = Title;
            this.Body = Body;
        }

        public override bool Equals(object? obj)
        {
            return obj is PostModel model &&
                   UserId == model.UserId &&
                   Id == model.Id &&
                   Title == model.Title &&
                   Body == model.Body;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, Id, Title, Body);
        }
    }
}