namespace UserOrderSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public string Item { get; set; }
    }
}