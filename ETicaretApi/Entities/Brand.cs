namespace ETicaretApi.Entities
{
    //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class Brand
    {
        public int BrandID { get; set; }
        public string ImgSrc { get; set; }
        public string Name { get; set; }


    }
}
