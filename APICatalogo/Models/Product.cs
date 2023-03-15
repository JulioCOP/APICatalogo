using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName="decimal(10,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float stock { get; set; }

    public DateTime DateRegistration { get; set; }

    //propriedade que mapea a coluna Id, criada na tabela produtos
    public int CategoryId { get; set; }

    // propriedade que define que cada produto está relacionada por um produto

    [JsonIgnore]
    public Category? Category { get; set; }
}
