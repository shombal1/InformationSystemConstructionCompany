using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddedLinksBetweenExpensesAndPoject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "RegularExpenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "OneTimeExpenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_ProjectId",
                table: "RegularExpenses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimeExpenses_ProjectId",
                table: "OneTimeExpenses",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneTimeExpenses_Projects_ProjectId",
                table: "OneTimeExpenses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_Projects_ProjectId",
                table: "RegularExpenses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneTimeExpenses_Projects_ProjectId",
                table: "OneTimeExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_Projects_ProjectId",
                table: "RegularExpenses");

            migrationBuilder.DropIndex(
                name: "IX_RegularExpenses_ProjectId",
                table: "RegularExpenses");

            migrationBuilder.DropIndex(
                name: "IX_OneTimeExpenses_ProjectId",
                table: "OneTimeExpenses");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "RegularExpenses");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "OneTimeExpenses");
        }
    }
}
