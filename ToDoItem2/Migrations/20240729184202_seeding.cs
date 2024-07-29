using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoItem2.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDoItems_Users_userId",
                table: "toDoItems");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "toDoItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_toDoItems_userId",
                table: "toDoItems",
                newName: "IX_toDoItems_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "toDoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "toDoItems",
                columns: new[] { "taskNum", "UserId", "done", "taskName" },
                values: new object[,]
                {
                    { 1, null, false, "Task 1" },
                    { 2, null, false, "Task 2" },
                    { 3, null, false, "Task 3" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_toDoItems_Users_UserId",
                table: "toDoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toDoItems_Users_UserId",
                table: "toDoItems");

            migrationBuilder.DeleteData(
                table: "toDoItems",
                keyColumn: "taskNum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "toDoItems",
                keyColumn: "taskNum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "toDoItems",
                keyColumn: "taskNum",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "toDoItems",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_toDoItems_UserId",
                table: "toDoItems",
                newName: "IX_toDoItems_userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "toDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_toDoItems_Users_userId",
                table: "toDoItems",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
