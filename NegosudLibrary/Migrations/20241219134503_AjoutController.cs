using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegosudLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AjoutController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_StatutCommande_statutcommandeid",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatutCommande",
                table: "StatutCommande");

            migrationBuilder.RenameTable(
                name: "StatutCommande",
                newName: "StatutCommandes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatutCommandes",
                table: "StatutCommandes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_StatutCommandes_statutcommandeid",
                table: "Commandes",
                column: "statutcommandeid",
                principalTable: "StatutCommandes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_StatutCommandes_statutcommandeid",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatutCommandes",
                table: "StatutCommandes");

            migrationBuilder.RenameTable(
                name: "StatutCommandes",
                newName: "StatutCommande");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatutCommande",
                table: "StatutCommande",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_StatutCommande_statutcommandeid",
                table: "Commandes",
                column: "statutcommandeid",
                principalTable: "StatutCommande",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
