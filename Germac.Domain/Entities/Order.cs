namespace Germac.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order(long orderId, decimal totalPrice) : base(DateTime.Now, null)
        {
            this.OrderId = orderId;
            this.TotalPrice = totalPrice;
        }

        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
