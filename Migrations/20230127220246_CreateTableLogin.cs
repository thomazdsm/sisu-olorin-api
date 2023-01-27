using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisuolorinapi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuthorizedAt",
                table: "AccessPermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastAccess = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropColumn(
                name: "AuthorizedAt",
                table: "AccessPermissions");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "DataCadastro");
        }
    }
}
