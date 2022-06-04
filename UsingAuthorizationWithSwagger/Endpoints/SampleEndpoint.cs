using FastEndpoints;

namespace UsingAuthorizationWithSwagger.Endpoints;

public class SampleEndpoint : Endpoint<EmptyRequest>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("example");
        Roles("admin");
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        await SendAsync(new
        {
            message = "Hello world"
        }, cancellation: ct);
    }
}