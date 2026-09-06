namespace ClientApp.Models;

/// <summary>
/// Product model representing product details in InventoryHub.
/// Configured with Copilot to support nested Category serialization.
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
    public Category? Category { get; set; }
}

