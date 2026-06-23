using DeliverySystem.Database;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Features.Products;

internal sealed class ListProducts(AppDbContext context)
{
    public sealed record Response(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        bool IsAvailable,
        DateTime CreatedAt);

    public async Task<List<Response>> Handle()
    {
        return await context.Products
            .AsNoTracking()
            .Select(product => new Response(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.IsAvailable,
                product.CreatedAt))
            .ToListAsync();
    }
}
