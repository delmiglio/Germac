namespace Germac.Infrastructure.Queries
{
    public class PartOrderQueries
    {
        public const string Get = @"SELECT * FROM PartStockOrder";

        public const string Find = @"SELECT * FROM PartStockOrder WHERE PartId = @PartId AND OrderId = @OrderId;";

        public const string Insert = @"INSERT INTO PartStockOrder(PartId, OrderId, Quantity, OrderDate, CreateDate)
                                        VALUES(@PartId, @OrderId, @Quantity, @OrderDate, @CreateDate); SELECT_LAST_ID();";

        public const string Update = @"UPDATE PartStockOrder
                                        SET Quantity = @Quantity,
                                            OrderDate = @OrderDate,
                                            UpdateDate = @UpdateDate
                                        WHERE PartId = @PartId AND OrderId = @OrderId;";

        public const string Delete = @"DELETE * FROM PartStockOrder WHERE PartId = @PartId AND OrderId = @OrderId;";
        
    }
}
