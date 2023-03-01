using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace APICatalogo.Models;

public class Category
{
    public Category()
    {
        Products= new Collection<Product>(); //inicio da coleção da classe
    }
    // Definindo entidades
    public int CategoryID { get; set; }
    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    //definindo a propriedade de navegação entre as tabelas -  estebelecendo a relação de Coluna para produtos
    public ICollection<Product>? Products { get; set; }
}
