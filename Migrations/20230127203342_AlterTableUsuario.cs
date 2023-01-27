using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisuolorinapi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco_1",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco_2",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Usuarios",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Usuarios",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Usuarios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Usuarios",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Usuarios",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Usuarios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuarios",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_1",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_2",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
