using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConfigureOnetoManyRelationshipbetweenContractandCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_CategoryId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CategoryId",
                table: "Contracts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_CategoryId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CategoryId",
                table: "Contracts",
                column: "CategoryId",
                unique: true);
        }
    }
}
