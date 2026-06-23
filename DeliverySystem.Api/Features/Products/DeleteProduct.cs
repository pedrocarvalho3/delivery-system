using DeliverySystem.Database;

namespace DeliverySystem.Features.Products;

internal sealed class DeleteProduct(AppDbContext context)
{
    public async Task<bool> Handle(Guid id)
    {
        var product = await context.Products.FindAsync(id);

        if (product is null)
        {
            return false;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return true;
    }
}
