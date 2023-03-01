using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //configurar o contexto no framework
    {

    }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
}
