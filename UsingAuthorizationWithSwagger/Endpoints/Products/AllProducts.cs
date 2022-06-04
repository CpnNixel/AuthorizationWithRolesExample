using FastEndpoints;
using UsingAuthorizationWithSwagger.Data;

namespace UsingAuthorizationWithSwagger.Endpoints.Products;

public class AllProducts : Endpoint<EmptyRequest>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("getAllProducts");
        Roles("admin");
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var products = ProductStore.GetProducts();

        await SendOkAsync(products, ct);
    }
}