namespace DeliverySystem.Features.Products;

public class ProductEndpoints
{
    private const string Tag = "Products";

    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("products", async (ListProducts useCase, int pageNumber, int pageSize) =>
        {
            var request = new ListProducts.Request(pageNumber, pageSize);
            
            var response = await useCase.Handle(request);

            return Results.Ok(response);
        })
        .WithTags(Tag)
        .RequireAuthorization();

        builder.MapPost("products/register", async (RegisterProduct.Request request, RegisterProduct useCase) =>
            {
                var product = await useCase.Handle(request);

                return Results.Created(
                    $"/restaurants/products/{product.Id}",
                    product);
            })
            .WithTags(Tag)
            .RequireAuthorization();

        builder.MapPut("products/{id:guid}", async (Guid id, UpdateProduct.Request request, UpdateProduct useCase) =>
            {
                var product = await useCase.Handle(id, request);

                return product is null
                    ? Results.NotFound()
                    : Results.Ok(product);
            })
            .WithTags(Tag)
            .RequireAuthorization();

        builder.MapPatch("products/{id:guid}/availability", async (Guid id, SwitchProductAvailability useCase) =>
            {
                var product = await useCase.Handle(id);

                return product is null
                    ? Results.NotFound()
                    : Results.Ok(product);
            })
            .WithTags(Tag)
            .RequireAuthorization();

        builder.MapDelete("products/{id:guid}", async (Guid id, DeleteProduct useCase) =>
            {
                var deleted = await useCase.Handle(id);

                return deleted
                    ? Results.NoContent()
                    : Results.NotFound();
            })
            .WithTags(Tag)
            .RequireAuthorization();
        
        return builder;
    }
}
