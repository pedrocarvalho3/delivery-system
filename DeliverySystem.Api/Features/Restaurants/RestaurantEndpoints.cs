namespace DeliverySystem.Api.Features.Restaurants;

internal static class RestaurantEndpoints
{
    private const string Tag = "Restaurants";

    public static IEndpointRouteBuilder Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("restaurants", async (ListRestaurants useCase) =>
                await useCase.Handle())
                .WithTags(Tag)
                .RequireAuthorization();
        
        return builder;
    }
}