using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class usernullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_userId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_userId",
                table: "posts",
                newName: "IX_posts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_UserId",
                table: "posts",
                newName: "IX_posts_userId");

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_userId",
                table: "posts",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
