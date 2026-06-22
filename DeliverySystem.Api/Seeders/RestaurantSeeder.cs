using DeliverySystem.Database;
using DeliverySystem.Api.Features.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Api.Seeders;

public static class RestaurantSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Restaurants.AnyAsync())
            return;

        var owner = await context.Users
            .FirstOrDefaultAsync(x => x.Email == "admin@delivery.com");

        if (owner is null)
            throw new Exception("Nenhum usuário encontrado para ser dono do restaurante.");

        var restaurant = new Restaurant
        {
            Id = Guid.NewGuid(),
            OwnerId = owner.Id,
            Name = "Sabores da China",
            Phone = "(11) 99999-9999",
            Document = "12.345.678/0001-90",
            IsOpen = true,
            CreatedAt = DateTime.UtcNow
        };

        context.Restaurants.Add(restaurant);

        await context.SaveChangesAsync();
    }
}