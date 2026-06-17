using DeliverySystem.Database;
using Microsoft.AspNetCore.Identity;
using DeliverySystem.Api.Users.Infrastructure;

namespace DeliverySystem.Api.Users;

internal sealed class LoginUser(AppDbContext context, PasswordHasher passwordHasher)
{
    public sealed record Request(string Email, string Password);

    public async Task<User> Handle(Request request)
    {
        User? user = await context.Users.GetByEmail(request.Email);

        if (user is null)
        {
            throw new Exception("The user was not found.");
        }
        
        bool verified = passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!verified)
        {
            throw new Exception("The password is incorrect");
        }
        
        return user;
    }
}