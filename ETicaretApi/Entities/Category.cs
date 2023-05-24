namespace ETicaretApi.Entities
{
    //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class Category
    {
        public int CategoryID { get; set; }
        public string ImgSrc { get; set; }
        public string Name { get; set; }

    }
}
