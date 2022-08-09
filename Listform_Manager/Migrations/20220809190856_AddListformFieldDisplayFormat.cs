using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformFieldDisplayFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayFormat",
                table: "Listform_Field",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayFormat",
                table: "Listform_Field");
        }
    }
}
