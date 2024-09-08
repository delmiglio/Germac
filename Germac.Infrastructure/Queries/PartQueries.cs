
namespace Germac.Infrastructure.Queries
{
    public static class PartQueries
    {
        public static string Get = @"SELECT * FROM Part;";

        public static string Find = @"SELECT * FROM Part WHERE ID = @ID;";

        public static string Insert = @"INSERT INTO Part (PartId, PartNumber, Name, Quantity, Price, CreateDate)
                                        VALUES (@PartId, @PartNumber, @Name, @Quantity, @Price, @CreateDate);";

        public static string Update = @"UPDATE Part
                                        SET PartNumber = @PartNumber,
                                            Name = @Name,
                                            Quantity = @Quantity,
                                            Price = @Price,
                                            UpdateDate = @UpdateDate
                                        WHERE PartId = @PartId;";

        public static string Delete = @"DELETE * FROM Part Where ID = @ID;";
    }
}
