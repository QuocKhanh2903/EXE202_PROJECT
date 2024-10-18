using System.Security;

namespace ArtFold.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public string UserID { get; set; }
        public User? User { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Note {  get; set; }
        public double TotalPrice {  get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
