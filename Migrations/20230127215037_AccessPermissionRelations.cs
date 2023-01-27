using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisuolorinapi.Migrations
{
    /// <inheritdoc />
    public partial class AccessPermissionRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccessPermissions_ProfileTypeId",
                table: "AccessPermissions",
                column: "ProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPermissions_UserId",
                table: "AccessPermissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPermissions_ProfileTypes_ProfileTypeId",
                table: "AccessPermissions",
                column: "ProfileTypeId",
                principalTable: "ProfileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPermissions_Users_UserId",
                table: "AccessPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPermissions_ProfileTypes_ProfileTypeId",
                table: "AccessPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessPermissions_Users_UserId",
                table: "AccessPermissions");

            migrationBuilder.DropIndex(
                name: "IX_AccessPermissions_ProfileTypeId",
                table: "AccessPermissions");

            migrationBuilder.DropIndex(
                name: "IX_AccessPermissions_UserId",
                table: "AccessPermissions");
        }
    }
}
