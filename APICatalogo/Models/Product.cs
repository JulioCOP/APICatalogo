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

    //propriedade que mapea a coluna Id, criada na tabela produtos
    public int CategoryId { get; set; }

    // propriedade que define que cada produto está relacionada por um produto
    public Category? Category { get; set; }
}
