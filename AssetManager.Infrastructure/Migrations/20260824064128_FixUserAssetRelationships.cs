using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserAssetRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserId1",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTransactions_Users_UserId1",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AssetTransactions_UserId1",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UserId1",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AssetTransactions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Assets");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Assets_UserId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "AssetTransactions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Assets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransactions_UserId1",
                table: "AssetTransactions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId1",
                table: "Assets",
                column: "UserId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserId1",
                table: "Assets",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransactions_Users_UserId1",
                table: "AssetTransactions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
