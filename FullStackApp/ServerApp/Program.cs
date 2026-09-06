var builder = WebApplication.CreateBuilder(args);

// Enable CORS for cross-origin requests from ClientApp (Copilot Integration)
builder.Services.AddCors();

// Copilot Performance Optimization:
// Add Output Caching to minimize backend database and server processing load for static product listings.
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(cachePolicyBuilder => cachePolicyBuilder.Expire(TimeSpan.FromSeconds(60)));
});

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Enable Output Caching middleware (Copilot Optimization)
app.UseOutputCache();

/*
 * Minimal API Endpoint: /api/productlist
 * Copilot Integration & JSON Structure Optimization:
 * Generates standardized, camelCase JSON payloads with nested Category entities (Id, Name).
 * Adheres to industry standards for API REST responses and enables effortless front-end deserialization.
 * CacheOutput() applies 60-second response caching to reduce server workload.
 */
app.MapGet("/api/productlist", () =>
{
    return new[]
    {
        new
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new { Id = 101, Name = "Electronics" }
        },
        new
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new { Id = 102, Name = "Accessories" }
        }
    };
}).CacheOutput();

app.Run();
