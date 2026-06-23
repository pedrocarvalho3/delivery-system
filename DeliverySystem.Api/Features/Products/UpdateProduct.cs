using DeliverySystem.Database;
using DeliverySystem.Features.Products.Infrastructure;

namespace DeliverySystem.Features.Products;

internal sealed class UpdateProduct(AppDbContext context)
{
    public sealed record Request(string Name, string Description, decimal Price);

    public sealed record Response(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        bool IsAvailable,
        DateTime CreatedAt);

    public async Task<Response?> Handle(Guid id, Request request)
    {
        var product = await context.Products.FindAsync(id);

        if (product is null)
        {
            return null;
        }

        if (await context.Products.Exists(id, request.Name))
        {
            throw new Exception($"Product with name {request.Name} already exists");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        await context.SaveChangesAsync();

        return new Response(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.IsAvailable,
            product.CreatedAt);
    }
}
