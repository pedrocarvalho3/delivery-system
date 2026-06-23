namespace DeliverySystem.Features.Products;

public class ProductEndpoints
{
    private const string Tag = "Products";

    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("products/register", async (RegisterProduct.Request request, RegisterProduct useCase) =>
            {
                var product = await useCase.Handle(request);

                return Results.Created(
                    $"/restaurants/products/{product.Id}",
                    product);
            })
            .WithTags(Tag)
            .RequireAuthorization();       
        
        return builder;
    }
}