using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Features.Products.Infrastructure;

internal static class ProductDbSetExtension
{
    public static async Task<bool> Exists(this DbSet<Product> products, string name)
    {
        return await products.AnyAsync();
    }
}