using DeliverySystem.Api.Users;
using DeliverySystem.Database;
using DeliverySystem.Api.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("DeliverySystemDb");
});

builder.Services.AddSingleton<PasswordHasher>();
builder.Services.AddSingleton<TokenProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.CustomSchemaIds(id => id.FullName!.Replace('+', '-')));

builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<LoginUser>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

UserEndpoints.Map(app);

app.Run();
