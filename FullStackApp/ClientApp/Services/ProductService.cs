namespace ClientApp.Services;

using System.Net.Http.Json;
using System.Text.Json;
using ClientApp.Models;

/// <summary>
/// ProductService handles API integration and client-side response caching.
/// Implementation & performance optimizations designed with Copilot assistance.
/// </summary>
public class ProductService
{
    private readonly HttpClient _httpClient;
    private Product[]? _cachedProducts;
    private DateTime _lastFetchTime;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(2);

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Checks if a valid non-expired client cache exists.
    /// Copilot Optimization: Eliminates redundant HTTP requests when navigating views.
    /// </summary>
    public bool HasValidCache()
    {
        return _cachedProducts != null && (DateTime.UtcNow - _lastFetchTime) < CacheDuration;
    }

    /// <summary>
    /// Fetches product list from Minimal API backend with in-memory client caching.
    /// </summary>
    public async Task<Product[]> GetProductsAsync(bool forceRefresh = false)
    {
        if (!forceRefresh && HasValidCache())
        {
            return _cachedProducts!;
        }

        var response = await _httpClient.GetAsync("http://localhost:5261/api/productlist");
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _cachedProducts = JsonSerializer.Deserialize<Product[]>(json, options) ?? Array.Empty<Product>();
        _lastFetchTime = DateTime.UtcNow;

        return _cachedProducts;
    }
}

