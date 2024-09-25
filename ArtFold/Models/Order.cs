using System.Security;

namespace ArtFold.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public string UserID { get; set; }
        public User? User { get; set; }
        public string City {  get; set; }
        public string District {  get; set; }
        public string Ward {  get; set; }
        public DateTime OrderDate { get; set; }
        public string? Note {  get; set; }
        public decimal TotalPrice {  get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
