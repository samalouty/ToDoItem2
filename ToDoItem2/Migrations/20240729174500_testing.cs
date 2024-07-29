using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoItem2.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "taskNum",
                table: "toDoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AlterColumn<int>(
                name: "taskNum",
                table: "toDoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

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
