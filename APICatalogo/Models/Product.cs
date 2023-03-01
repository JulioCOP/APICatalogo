namespace APICatalogo.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public float stock { get; set; }

    public DateTime DateRegistration { get; set; }
}
