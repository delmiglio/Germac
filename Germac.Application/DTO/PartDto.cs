namespace Germac.Application.DTO
{
    public class PartDTO
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public string? PartNumber { get; set; }
        public string? Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
