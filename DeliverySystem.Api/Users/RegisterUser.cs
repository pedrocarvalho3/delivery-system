using DeliverySystem.Api.Users.Infrastructure;
using DeliverySystem.Database;

namespace DeliverySystem.Api.Users;

internal sealed class RegisterUser(AppDbContext context, PasswordHasher passwordHasher)
{
    public sealed record Request(string Email, string Password, string FirstName, string LastName);
    
    public sealed record Response(Guid Id, string Email, string FirstName, string LastName);

    public async Task<Response> Handle(Request request)
    {
        if (await context.Users.Exists(request.Email))
        {
            throw new Exception("The email is already in use");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = passwordHasher.Hash(request.Password)
        };

        context.Add(user);
        await context.SaveChangesAsync();
        return new Response(user.Id, user.Email, user.FirstName, user.LastName);
    }
}