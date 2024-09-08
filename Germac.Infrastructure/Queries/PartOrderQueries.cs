namespace Germac.Infrastructure.Queries
{
    public class PartOrderQueries
    {
        public static string Get = @"SELECT * FROM PartStockOrder";

        public static string Find = @"SELECT * FROM PartStockOrder WHERE PartId = @PartId AND OrderId = @OrderId;";

        public static string Insert = @"INSERT INTO PartStockOrder(PartId, OrderId, Quantity, OrderDate, CreateDate)
                                        VALUES(@PartId, @OrderId, @Quantity, @OrderDate, @CreateDate);";

        public static string Update = @"UPDATE PartStockOrder
                                        SET Quantity = @Quantity,
                                            OrderDate = @OrderDate,
                                            UpdateDate = @UpdateDate
                                        WHERE PartId = @PartId AND OrderId = @OrderId;";

        public static string Delete = @"DELETE * FROM PartStockOrder WHERE PartId = @PartId AND OrderId = @OrderId;";
        
    }
}
