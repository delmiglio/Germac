namespace Germac.Application.DTO
{
    public class OrderDTO
    {
        public long OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
