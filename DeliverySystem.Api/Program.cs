using System.Text;
using DeliverySystem.Api.Features.Restaurants;
using DeliverySystem.Api.Features.Users;
using DeliverySystem.Database;
using DeliverySystem.Api.Features.Users.Infrastructure;
using DeliverySystem.Extensions;
using DeliverySystem.Features.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

const string frontendCorsPolicy = "FrontendCorsPolicy";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<PasswordHasher>();
builder.Services.AddSingleton<TokenProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddCors(options =>
{
    options.AddPolicy(frontendCorsPolicy, policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:SecretKey"]
                    ?? throw new InvalidOperationException("Jwt:SecretKey is not configured."))),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true
        };
    });

builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<LoginUser>();

builder.Services.AddScoped<ListRestaurants>();

builder.Services.AddScoped<RegisterProduct>();
builder.Services.AddScoped<ListProducts>();
builder.Services.AddScoped<UpdateProduct>();
builder.Services.AddScoped<DeleteProduct>();
builder.Services.AddScoped<SwitchProductAvailability>();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//
//     await RestaurantSeeder.SeedAsync(context);
// }

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(frontendCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

UserEndpoints.Map(app);
RestaurantEndpoints.Map(app);
ProductEndpoints.Map(app); 

app.Run();
