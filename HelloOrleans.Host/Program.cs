using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(silo =>
{
    silo.UseLocalhostClustering();
    // silo.AddMemoryGrainStorage("hello-orleans");
    silo.UseMongoDBClient("mongodb://localhost")
        .AddMongoDBGrainStorage("hello-orleans", options =>
        {
            options.DatabaseName = "hello-orleans";
            options.CollectionPrefix = "";
        });
});
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
