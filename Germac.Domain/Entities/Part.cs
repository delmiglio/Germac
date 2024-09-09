namespace Germac.Domain.Entities
{
    public class Part : BaseEntity
    {
        public Part(long partId, string? partNumber, string? name, long quantity, decimal price) : base(DateTime.Now, null)
        {
            this.PartId = partId;
            this.PartNumber = partNumber;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public Part() : base(null, null)
        {
            
        }

        public Part(long partId, long quantity) : base(DateTime.Now, null)
        {
            this.PartId = partId;
            this.Quantity = quantity;
        }

        public long Id { get; set; }
        public long PartId { get; set; }
        public string? PartNumber { get; set; }
        public string? Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
