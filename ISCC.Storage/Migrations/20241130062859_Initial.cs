using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OneTimeExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlannedEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegularExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TotalLaborIntensity = table.Column<decimal>(type: "numeric", nullable: false),
                    AverageMonthlyWorkers = table.Column<int>(type: "integer", nullable: false),
                    PlannedDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreviousPlanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPlans_ProjectPlans_PreviousPlanId",
                        column: x => x.PreviousPlanId,
                        principalTable: "ProjectPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPlans_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Payment = table.Column<DateOnly>(type: "date", nullable: false),
                    RegularExpensesId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MaterialWorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlannedQuantity = table.Column<int>(type: "integer", nullable: false),
                    ContractMaterialUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ContractWorkUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    PlannedMaterialUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    PlannedWorkUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    LaborIntensity = table.Column<decimal>(type: "numeric", nullable: false),
                    ProjectPlanId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "ActualMaterialWorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualQuantity = table.Column<int>(type: "integer", nullable: false),
                    ActualMaterialCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualWorkCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualWorkers = table.Column<int>(type: "integer", nullable: false),
                    MaterialWorkItemId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ActualMaterialWorkItems_MaterialWorkItemId",
                table: "ActualMaterialWorkItems",
                column: "MaterialWorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialWorkItems_ProjectPlanId",
                table: "MaterialWorkItems",
                column: "ProjectPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDates_RegularExpensesId",
                table: "PaymentDates",
                column: "RegularExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlans_PreviousPlanId",
                table: "ProjectPlans",
                column: "PreviousPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPlans_ProjectId",
                table: "ProjectPlans",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "ProjectPlans");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
