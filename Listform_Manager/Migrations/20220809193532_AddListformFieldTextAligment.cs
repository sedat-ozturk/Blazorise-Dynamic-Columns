using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformFieldTextAligment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextAlignment",
                table: "Listform_Field",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextAlignment",
                table: "Listform_Field");
        }
    }
}
