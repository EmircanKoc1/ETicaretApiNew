namespace ETicaretApi.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }

        public float TotalPrice { get; set; }

        public bool OrderStatus { get; set; }



    }
}
