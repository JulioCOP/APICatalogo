using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
[Table("Categories")]
public class Category
{

    public Category()
    {
        Products= new Collection<Product>(); //inicio da coleção da classe
    }
    // Definindo entidades
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(300)]
    [BindNever] //propriedade ImageUrl, ignora a vinculação da propriedade 
    public string? ImageUrl { get; set; }

    //definindo a propriedade de navegação entre as tabelas 
    public ICollection<Product>? Products { get; set; } // Uma categoria pode ter muitos produtos
}
