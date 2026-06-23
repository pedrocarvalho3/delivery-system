using DeliverySystem.Database;
using DeliverySystem.Features.Products.Infrastructure;

namespace DeliverySystem.Features.Products;

internal sealed class RegisterProduct(AppDbContext context)
{
    public sealed record Request(string Name,  string Description, decimal Price);
    
    public sealed record Response(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        bool IsAvailable,
        DateTime CreatedAt);

    public async Task<Response> Handle(Request request)
    {
        if (await context.Products.Exists(request.Name))
        {
            throw new Exception($"Product with name {request.Name} already exists");
        }

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };
        
        context.Add(product);
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