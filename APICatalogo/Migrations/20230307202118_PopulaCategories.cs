using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Bebidas', 'bebidas.jpg') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
