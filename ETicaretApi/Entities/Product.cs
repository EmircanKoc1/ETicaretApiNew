namespace ETicaretApi.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }

        public int Price { get; set; }

        public string PreDescription { get; set; }

        public string Description { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

        public string ImgSrc { get; set; }
    }
}
