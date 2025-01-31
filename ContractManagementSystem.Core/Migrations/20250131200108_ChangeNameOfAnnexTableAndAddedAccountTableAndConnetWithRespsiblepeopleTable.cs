using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManagementSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfAnnexTableAndAddedAccountTableAndConnetWithRespsiblepeopleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Addendums_AddendumId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Addendums_AddendumId",
                table: "ResponsiblePersons");

            migrationBuilder.DropTable(
                name: "Addendums");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ResponsiblePersons");

            migrationBuilder.RenameColumn(
                name: "AddendumId",
                table: "ResponsiblePersons",
                newName: "AnnexId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsiblePersons_AddendumId",
                table: "ResponsiblePersons",
                newName: "IX_ResponsiblePersons_AnnexId");

            migrationBuilder.RenameColumn(
                name: "AddendumId",
                table: "ProductItems",
                newName: "AnnexId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_AddendumId",
                table: "ProductItems",
                newName: "IX_ProductItems_AnnexId");

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ResponsiblePersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_ResponsiblePersons_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "ResponsiblePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annexes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnnexNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annexes_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ResponsiblePersonId",
                table: "Accounts",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Annexes_ContractId",
                table: "Annexes",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Annexes_AnnexId",
                table: "ProductItems",
                column: "AnnexId",
                principalTable: "Annexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Annexes_AnnexId",
                table: "ResponsiblePersons",
                column: "AnnexId",
                principalTable: "Annexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Annexes_AnnexId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Annexes_AnnexId",
                table: "ResponsiblePersons");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Annexes");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "ProductItems");

            migrationBuilder.RenameColumn(
                name: "AnnexId",
                table: "ResponsiblePersons",
                newName: "AddendumId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsiblePersons_AnnexId",
                table: "ResponsiblePersons",
                newName: "IX_ResponsiblePersons_AddendumId");

            migrationBuilder.RenameColumn(
                name: "AnnexId",
                table: "ProductItems",
                newName: "AddendumId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_AnnexId",
                table: "ProductItems",
                newName: "IX_ProductItems_AddendumId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ResponsiblePersons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ResponsiblePersons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "ResponsiblePersons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Addendums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddendumNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addendums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addendums_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addendums_ContractId",
                table: "Addendums",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Addendums_AddendumId",
                table: "ProductItems",
                column: "AddendumId",
                principalTable: "Addendums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Addendums_AddendumId",
                table: "ResponsiblePersons",
                column: "AddendumId",
                principalTable: "Addendums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
