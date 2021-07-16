using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Mutants.Migrations
{
    public partial class AddDnaInfoStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dna",
                table: "Stats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dna",
                table: "Stats");
        }
    }
}
