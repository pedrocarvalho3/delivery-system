using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Api.Features.Restaurants.Infrastructure;

internal static class RestaurantDbSetExtension
{
    public static async Task<bool> Exists(this DbSet<Restaurant> restaurants)
    {
        return await restaurants.AnyAsync();
    }

    public static async Task<List<Restaurant>> GetAllRestaurants(this DbSet<Restaurant> restaurants)
    {
        return await restaurants.ToListAsync();
    }
}