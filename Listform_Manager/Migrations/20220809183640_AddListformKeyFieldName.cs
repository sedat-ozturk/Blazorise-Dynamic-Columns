using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformKeyFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyFieldName",
                table: "Listform",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyFieldName",
                table: "Listform");
        }
    }
}
