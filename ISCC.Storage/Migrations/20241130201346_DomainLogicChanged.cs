using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class DomainLogicChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPlans_ProjectPlans_PreviousPlanId",
                table: "ProjectPlans");

            migrationBuilder.DropTable(
                name: "ActualMaterialWorkItems");

            migrationBuilder.DropTable(
                name: "OneTimeExpenses");

            migrationBuilder.DropTable(
                name: "PaymentDates");

            migrationBuilder.DropTable(
                name: "MaterialWorkItems");

            migrationBuilder.DropTable(
                name: "RegularExpenses");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPlans_PreviousPlanId",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "PreviousPlanId",
                table: "ProjectPlans");

            migrationBuilder.RenameColumn(
                name: "PlannedLaborIntensity",
                table: "ProjectPlans",
                newName: "TotalCostPriceWork");

            migrationBuilder.RenameColumn(
                name: "AverageMonthlyWorkers",
                table: "ProjectPlans",
                newName: "TotalLabor");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProjectPlans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPrice",
                table: "ProjectPlans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPriceMaterial",
                table: "ProjectPlans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalActualPriceWork",
                table: "ProjectPlans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPrice",
                table: "ProjectPlans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPriceMaterial",
                table: "ProjectPlans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PercentageContent = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalActualPriceMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalActualPriceWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalActualPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalLabor = table.Column<int>(type: "integer", nullable: false),
                    TotalCostPriceMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostPriceWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ProjectPlanId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ProjectPlans_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalTable: "ProjectPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Surcharge = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPricePerUnitMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPricePerUnitWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostPriceMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostPriceWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualPricePerUnitMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualPricePerUnitWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalActualPriceMaterial = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalActualPriceWork = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalActualPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_ProjectPlans_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalTable: "ProjectPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProjectPlanId",
                table: "Resources",
                column: "ProjectPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UnitTypeId",
                table: "Resources",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectPlanId",
                table: "Tasks",
                column: "ProjectPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "TotalActualPrice",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "TotalActualPriceMaterial",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "TotalActualPriceWork",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "TotalCostPrice",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "TotalCostPriceMaterial",
                table: "ProjectPlans");

            migrationBuilder.RenameColumn(
                name: "TotalLabor",
                table: "ProjectPlans",
                newName: "AverageMonthlyWorkers");

            migrationBuilder.RenameColumn(
                name: "TotalCostPriceWork",
                table: "ProjectPlans",
                newName: "PlannedLaborIntensity");

            migrationBuilder.AddColumn<Guid>(
                name: "PreviousPlanId",
                table: "ProjectPlans",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialWorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractMaterialUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ContractWorkUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    LaborIntensity = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlannedMaterialUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    PlannedQuantity = table.Column<int>(type: "integer", nullable: false),
                    PlannedWorkUnitCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialWorkItems_ProjectPlans_ProjectPlanId",
                        column: x => x.ProjectPlanId,
                        principalTable: "ProjectPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "RegularExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "ActualMaterialWorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialWorkItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActualMaterialCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualQuantity = table.Column<int>(type: "integer", nullable: false),
                    ActualWorkCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualWorkers = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualMaterialWorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualMaterialWorkItems_MaterialWorkItems_MaterialWorkItemId",
                        column: x => x.MaterialWorkItemId,
                        principalTable: "MaterialWorkItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegularExpensesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Payment = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDates_RegularExpenses_RegularExpensesId",
                        column: x => x.RegularExpensesId,
                        principalTable: "RegularExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlans_PreviousPlanId",
                table: "ProjectPlans",
                column: "PreviousPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActualMaterialWorkItems_MaterialWorkItemId",
                table: "ActualMaterialWorkItems",
                column: "MaterialWorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialWorkItems_ProjectPlanId",
                table: "MaterialWorkItems",
                column: "ProjectPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimeExpenses_ProjectId",
                table: "OneTimeExpenses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDates_RegularExpensesId",
                table: "PaymentDates",
                column: "RegularExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_ProjectId",
                table: "RegularExpenses",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPlans_ProjectPlans_PreviousPlanId",
                table: "ProjectPlans",
                column: "PreviousPlanId",
                principalTable: "ProjectPlans",
                principalColumn: "Id");
        }
    }
}
