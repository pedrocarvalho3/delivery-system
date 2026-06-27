using DeliverySystem.Database;
using DeliverySystem.Features.Products;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Api.Seeders;

public static class ProductSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {

        Product[] products = new Product[]
        {
            new Product { Name = "Temaki", Description = "Temaki saboroso com arroz japones e peixe", Price = 10 },
            new Product { Name = "Sushi Salmao", Description = "Sushi de salmao fresco com arroz temperado", Price = 18 },
            new Product { Name = "Sashimi Salmao", Description = "Fatias de salmao fresco servidas com shoyu", Price = 24 },
            new Product { Name = "Hot Roll", Description = "Rolinho empanado com salmao e cream cheese", Price = 22 },
            new Product { Name = "Yakisoba Frango", Description = "Macarrao oriental com frango, legumes e molho especial", Price = 28 },
            new Product { Name = "Yakisoba Carne", Description = "Macarrao oriental com carne, legumes e molho especial", Price = 30 },
            new Product { Name = "Guioza", Description = "Pasteis orientais recheados com carne suina", Price = 16 },
            new Product { Name = "Rolinho Primavera", Description = "Rolinho crocante recheado com legumes", Price = 12 },
            new Product { Name = "Frango Xadrez", Description = "Frango com pimentao, cebola, amendoim e molho oriental", Price = 32 },
            new Product { Name = "Carne com Brocolis", Description = "Tiras de carne salteadas com brocolis e molho shoyu", Price = 35 },
            new Product { Name = "Arroz Chop Suey", Description = "Arroz oriental com ovos, legumes e presunto", Price = 20 },
            new Product { Name = "Missoshiro", Description = "Sopa japonesa de miso com tofu e cebolinha", Price = 11 },
            new Product { Name = "Sunomono", Description = "Salada agridoce de pepino com gergelim", Price = 9 },
            new Product { Name = "Ceviche", Description = "Peixe marinado no limao com cebola roxa e temperos", Price = 27 },
            new Product { Name = "Poke Salmao", Description = "Bowl com arroz, salmao, legumes, manga e molho especial", Price = 36 },
            new Product { Name = "Bao de Porco", Description = "Pao chines macio recheado com porco agridoce", Price = 19 },
            new Product { Name = "Lamen", Description = "Caldo oriental com macarrao, carne, ovo e legumes", Price = 34 },
            new Product { Name = "Tonkatsu", Description = "Lombo suino empanado servido com molho tonkatsu", Price = 31 },
            new Product { Name = "Tempura Legumes", Description = "Legumes empanados em massa leve e crocante", Price = 21 },
            new Product { Name = "Harumaki Chocolate", Description = "Rolinho doce recheado com chocolate cremoso", Price = 14 }
        };

        foreach (Product product in products)
        {
            await context.Products.AddAsync(product);
        }
        
        await context.SaveChangesAsync();
    }
}
