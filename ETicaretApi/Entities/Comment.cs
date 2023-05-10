namespace ETicaretApi.Entities
{
    public class Comment
    {

        public int CommentID { get; set; }
        public int ProductID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }
    }
}
