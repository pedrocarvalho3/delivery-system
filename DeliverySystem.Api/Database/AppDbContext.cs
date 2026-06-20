using DeliverySystem.Api.Users;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Database;

public class AppDbContext : DbContext
{
    public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users => Set<User>();
}