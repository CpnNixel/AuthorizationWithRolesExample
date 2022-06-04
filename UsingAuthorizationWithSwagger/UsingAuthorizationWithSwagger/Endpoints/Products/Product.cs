using FastEndpoints;
using UsingAuthorizationWithSwagger.Data;

namespace UsingAuthorizationWithSwagger.Endpoints.Products;

public class ByProductIdRequest
{
    public int ProductId { get; set; }
}

public class Product : Endpoint<ByProductIdRequest>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("getProductById");
        Roles("admin");
    }

    public override async Task HandleAsync(ByProductIdRequest req, CancellationToken ct)
    {
        var product = ProductStore.GetProduct(req.ProductId);

        if (product is null)
            await SendNotFoundAsync(ct);
        else
            await SendOkAsync(product, ct);

    }
}