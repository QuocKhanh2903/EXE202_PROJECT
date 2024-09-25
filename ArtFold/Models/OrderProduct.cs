namespace ArtFold.Models
{
    public class OrderProduct
    {
        public Guid OrderProductID { get; set; }  // Khóa chính
        public Guid OrderID { get; set; }
        public Order? Order { get; set; }

        public Guid ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
