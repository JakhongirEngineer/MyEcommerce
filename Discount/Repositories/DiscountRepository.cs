using Dapper;
using Discount.Entities;
using Npgsql;

namespace Discount.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly string _connectionString;

    public DiscountRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionStrings:Postgres")!;
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
            "SELECT * FROM COUPON WHERE ProductName = @ProductName", new { ProductName = productName }
        );

        return coupon ?? new Coupon()
        {
            ProductName = productName,
            Amount = 0,
            Description = "No discount available."
        };
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var affected = await connection.ExecuteAsync(
            "INSERT INTO COUPON (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount }
        );

        return affected > 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var affected = await connection.ExecuteAsync(
            "UPDATE COUPON SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
            new
            {
                ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount,
                Id = coupon.Id
            }
        );

        return affected > 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var affected = await connection.ExecuteAsync(
            "DELETE FROM COUPON WHERE ProductName = @ProductName",
            new { ProductName = productName });
        return affected > 0;
    }
}