namespace ArtFold.Models
{
    public class CheckOut
    {
        public Guid CheckOutID {  get; set; }
        public Guid OrderID { get; set; }
        public Order? Order { get; set; }
        public string PaymentMethod { get; set; }
    }
}
