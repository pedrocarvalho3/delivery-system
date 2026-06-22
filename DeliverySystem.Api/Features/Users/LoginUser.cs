using DeliverySystem.Database;
using Microsoft.AspNetCore.Identity;
using DeliverySystem.Api.Features.Users.Infrastructure;

namespace DeliverySystem.Api.Features.Users;

internal sealed class LoginUser(AppDbContext context, PasswordHasher passwordHasher, TokenProvider tokenProvider)
{
    public sealed record Request(string Email, string Password);

    public async Task<string> Handle(Request request)
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

        var token = tokenProvider.Create(user);
        
        return token;
    }
}