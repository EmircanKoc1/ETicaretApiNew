namespace ETicaretApi.Entities
{ //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }

        public float Price { get; set; }

        public string PreDescription { get; set; }

        public string Description { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

        public string ImgSrc { get; set; }
    }
}
