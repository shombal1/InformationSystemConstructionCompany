using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPrice",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPriceMaterial",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPriceWork",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPrice",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPriceMaterial",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPriceWork",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalLabor",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceExpense",
                table: "Projects",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OneTimeExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimeExpenses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OneTimeExpenses_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegularExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DurationInMonths = table.Column<double>(type: "double precision", nullable: false),
                    UnitTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegularExpenses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularExpenses_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OneTimeExpenses_ProjectId",
                table: "OneTimeExpenses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimeExpenses_UnitTypeId",
                table: "OneTimeExpenses",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_ProjectId",
                table: "RegularExpenses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_UnitTypeId",
                table: "RegularExpenses",
                column: "UnitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneTimeExpenses");

            migrationBuilder.DropTable(
                name: "RegularExpenses");

            migrationBuilder.DropColumn(
                name: "TotalActualPrice",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalActualPriceMaterial",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalActualPriceWork",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalCostPrice",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalCostPriceMaterial",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalCostPriceWork",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalLabor",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TotalPriceExpense",
                table: "Projects");
        }
    }
}
