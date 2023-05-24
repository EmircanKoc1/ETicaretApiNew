namespace ETicaretApi.Entities
{
    //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class BasketProduct
    {
        public int BasketProductID { get; set; }

        public int BasketID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }



    }
}
