using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBreno.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "values('Calça Chronic Save Animals 46', '99.00', 'Calça muito maneira', 5, 'CalçaChronicSaveAnimals.PNG', 1)");
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "values('Calça Chronic Save Animals 48', '99.00', 'Calça muito maneira', 10, 'CalçaChronicSaveAnimals.PNG', 1)");
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "values('Calça Chronic Save Animals 50', '99.00', 'Calça muito maneira', 7, 'CalçaChronicSaveAnimals.PNG', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Products");
        }
    }
}
