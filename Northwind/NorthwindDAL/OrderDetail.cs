namespace NorthwindDAL
{
    public class OrderDetail
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public decimal ExtendedPrice { get; set; }

        public int ProductID { get; set; }
    }
}