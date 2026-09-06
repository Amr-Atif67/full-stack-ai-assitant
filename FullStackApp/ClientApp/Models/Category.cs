namespace ClientApp.Models;

/// <summary>
/// Category model representing nested product category details.
/// Structured with Copilot assistance for standardized JSON deserialization.
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

