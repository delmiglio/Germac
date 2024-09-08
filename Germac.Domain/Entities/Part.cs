namespace Germac.Domain.Entities
{
    public class Part : BaseEntity
    {
        public Part(long id, long partId, string partNumber, string name, string quantity, decimal price) : base(DateTime.Now, null)
        {
            this.Id = id;
            this.PartId = partId;
            this.PartNumber = partNumber;
            this.Name = name;
            this.Price = price;
        }

        public long Id { get; set; }
        public long PartId { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
