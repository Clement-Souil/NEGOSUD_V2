using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegosudLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Modif_colonne_cmd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Commandes",
                newName: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Commandes",
                newName: "Date");
        }
    }
}
