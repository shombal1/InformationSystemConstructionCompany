using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class ProjectPlan_AddTemporaryProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDuration",
                table: "ProjectPlans");

            migrationBuilder.RenameColumn(
                name: "TotalLaborIntensity",
                table: "ProjectPlans",
                newName: "PlannedLaborIntensity");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "ProjectPlans",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PlannedEndDate",
                table: "ProjectPlans",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "ProjectPlans",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "PlannedEndDate",
                table: "ProjectPlans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ProjectPlans");

            migrationBuilder.RenameColumn(
                name: "PlannedLaborIntensity",
                table: "ProjectPlans",
                newName: "TotalLaborIntensity");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PlannedDuration",
                table: "ProjectPlans",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
