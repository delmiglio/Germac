
namespace Germac.Infrastructure.Queries
{
    public static class PartQueries
    {
        public const string Get = @"SELECT * FROM Part;";

        public const string FindById = @"SELECT * FROM Part WHERE ID = @ID;";

        public const string FindByPartId = @"SELECT * FROM Part WHERE PARTID = @ID;";

        public const string Insert = @"INSERT INTO Part (PartId, PartNumber, Name, Quantity, Price, CreateDate)
                                        VALUES (@PartId, @PartNumber, @Name, @Quantity, @Price, @CreateDate);
                                        SELECT LAST_INSERT_ID();";

        public const string Update = @"UPDATE Part
                                        SET PartNumber = @PartNumber,
                                            Name = @Name,
                                            Quantity = @Quantity,
                                            Price = @Price,
                                            UpdateDate = @UpdateDate
                                        WHERE PartId = @PartId;";

        public const string Delete = @"DELETE * FROM Part Where ID = @ID;";
    }
}
