namespace Germac.Infrastructure.Queries
{
    public static class OrderQueries
    {
        public static string Get = @"SELECT * FROM StockOrder;";

        public static string Find = @"SELECT * FROM StockOrder WHERE Id = @Id;";

        public static string Insert = @"INSERT INTO StockOrder (Id, OrderId, TotalPrice, CreateDate)
                                        VALUES (@Id, @OrderId, @TotalPrice, @CreateDate);";

        public static string Update = @"UPDATE StockOrder
                                        SET TotalPrice = @TotalPrice,
                                            UpdateDate = @UpdateDate
                                        WHERE OrderId = @OrderId;";

        public static string Delete = @"DELETE * FROM StockOrder WHERE Id = @Id;";

    }
}
