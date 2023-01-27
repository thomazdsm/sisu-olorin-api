using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sisuolorinapi.Migrations
{
    /// <inheritdoc />
    public partial class FixAndSeedTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlFile = Path.Combine("Migrations/Scripts/001_DefaultValueAndSeedTipoUsuario_26012023.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
