using DeliverySystem.Api.Users;

namespace DeliverySystem.Features.Restaurants;

public class Restaurant
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;

    public bool IsOpen { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}