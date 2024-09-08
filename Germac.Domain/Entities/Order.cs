namespace Germac.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order(long id, long orderId, decimal totalPrice) : base(DateTime.Now, null)
        {
            this.Id = id;
            this.OrderId = orderId;
            this.TotalPrice = totalPrice;
        }

        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
