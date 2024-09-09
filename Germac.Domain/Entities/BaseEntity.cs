namespace Germac.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity(DateTime? createDate, DateTime? updateDate)
        {
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
        }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
