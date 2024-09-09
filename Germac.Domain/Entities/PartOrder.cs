using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Germac.Domain.Entities
{
    public class PartOrder : BaseEntity
    {
        public PartOrder(long id, long partId, long orderId, long quantity) : base(DateTime.Now, null)
        {
            this.Id = id;
            this.PartId = partId;
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.OrderDate = DateTime.Now;
        }

        public long Id { get; set; }
        public long PartId { get; set; }
        public long OrderId { get; set; }
        public long Quantity { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
