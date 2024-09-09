using System.Text.Json.Serialization;

namespace Germac.Application.DTO
{
    public class OrderPartDTO
    {
        public long PartId { get; set; }
        public long Quantity { get; set; }

        [JsonIgnore]
        public string? Name { get; set; }
    }
}
