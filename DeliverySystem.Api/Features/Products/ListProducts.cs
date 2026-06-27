using DeliverySystem.Database;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Features.Products;

internal sealed class ListProducts(AppDbContext context)
{
    public sealed record Request(int PageNumber, int PageSize);
    
    public sealed record ProductsList(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        bool IsAvailable,
        DateTime CreatedAt);
    
    public sealed record Response(int PageNumber, int PageSize, List<ProductsList> Products);

    public async Task<Response> Handle(Request request)
    {
        var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
        var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

        var products = await context.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(product => new ProductsList(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.IsAvailable,
                product.CreatedAt))
            .ToListAsync();
         
        return new Response(pageNumber, pageSize, products);
    }
}
