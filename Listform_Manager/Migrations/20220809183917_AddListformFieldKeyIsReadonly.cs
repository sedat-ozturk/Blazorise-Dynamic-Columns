using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformFieldKeyIsReadonly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReadonly",
                table: "Listform_Field",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReadonly",
                table: "Listform_Field");
        }
    }
}
