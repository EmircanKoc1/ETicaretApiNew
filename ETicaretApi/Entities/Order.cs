namespace ETicaretApi.Entities
{   //Veritabanında karşılık gelmesi için Classı Entity olarak kullanacağız
    //İlgili class Veritabanında tabloya karşılık gelecek.
    public class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }

        public float TotalPrice { get; set; }

        public bool OrderStatus { get; set; }



    }
}
