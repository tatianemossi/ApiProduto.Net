namespace ProductApi.Net.Infra.SqlScripts
{
    public static class ProductScripts
    {
        public const string GetAll = "EXEC GetAllProducts";

        public const string GetById = "EXEC GetProductById @Id";

        public const string Insert =
            @"INSERT INTO Product
                      (CreatedAt, Name, Price, Brand, UpdateAt)
              VALUES
                      (@CreatedAt, @Name, @Price, @Brand, @UpdateAt);
              SELECT SCOPE_IDENTITY();";

        public const string Update =
            @"UPDATE Product SET
                Name = @Name,
                Price = @Price,
                Brand = @Brand,
                UpdateAt = @UpdateAt
              WHERE Id = @Id";

        public const string Delete = "DELETE FROM Product WHERE Id = @Id";
    }
}
