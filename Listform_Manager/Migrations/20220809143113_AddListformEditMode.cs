using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformEditMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditMode",
                table: "Listform",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditMode",
                table: "Listform");
        }
    }
}
