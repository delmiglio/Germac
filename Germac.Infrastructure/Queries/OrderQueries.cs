namespace Germac.Infrastructure.Queries
{
    public static class OrderQueries
    {
        public const string Get = @"SELECT * FROM StockOrder;";

        public const string FindById = @"SELECT * FROM StockOrder WHERE Id = @Id;";

        public const string FindByOrderId = @"SELECT * FROM StockOrder WHERE ORDERID = @ID;";

        public const string Insert = @"INSERT INTO StockOrder (Id, OrderId, TotalPrice, CreateDate)
                                        VALUES (@Id, @OrderId, @TotalPrice, @CreateDate); SELECT LAST_INSERT_ID();";

        public const string Update = @"UPDATE StockOrder
                                        SET TotalPrice = @TotalPrice,
                                            UpdateDate = @UpdateDate
                                        WHERE OrderId = @OrderId;";

        public const string Delete = @"DELETE * FROM StockOrder WHERE Id = @Id;";

    }
}
