using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Listform_Manager.Migrations
{
    public partial class AddListformColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Listform_Field",
                newName: "RowNo");

            migrationBuilder.AddColumn<string>(
                name: "ColumnType",
                table: "Listform_Field",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DbType",
                table: "Listform_Field",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnType",
                table: "Listform_Field");

            migrationBuilder.DropColumn(
                name: "DbType",
                table: "Listform_Field");

            migrationBuilder.RenameColumn(
                name: "RowNo",
                table: "Listform_Field",
                newName: "Order");
        }
    }
}
