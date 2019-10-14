using Microsoft.EntityFrameworkCore.Migrations;

namespace masteringToDoList.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ToDoItem");

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "ToDoList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "ToDoItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "ToDoItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoItem");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ToDoList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ToDoItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
