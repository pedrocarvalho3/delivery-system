using DeliverySystem.Database;

namespace DeliverySystem.Features.Products;

internal sealed class SwitchProductAvailability(AppDbContext context)
{
    public sealed record Response(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        bool IsAvailable,
        DateTime CreatedAt);

    public async Task<Response?> Handle(Guid id)
    {
        var product = await context.Products.FindAsync(id);

        if (product is null)
        {
            return null;
        }

        product.IsAvailable = !product.IsAvailable;

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
