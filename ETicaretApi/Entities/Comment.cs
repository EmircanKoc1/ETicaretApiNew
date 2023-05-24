namespace ETicaretApi.Entities
{   //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class Comment
    {

        public int CommentID { get; set; }
        public int ProductID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }
    }
}
