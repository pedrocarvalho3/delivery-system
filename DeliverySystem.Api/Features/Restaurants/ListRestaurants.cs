using DeliverySystem.Api.Features.Restaurants.Infrastructure;
using DeliverySystem.Database;

namespace DeliverySystem.Api.Features.Restaurants;

internal sealed class ListRestaurants(AppDbContext context)
{
    public async Task<List<Restaurant>> Handle()
    {
        var restaurants = await context.Restaurants.GetAllRestaurants();

        if (restaurants is null)
        {
            throw new ArgumentNullException($"Restaurant not found");
        }

        return restaurants;
    }
}