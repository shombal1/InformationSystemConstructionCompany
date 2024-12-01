using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Remove_FK_Resources_Projects_ProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Projects_ProjectId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Resources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Projects_ProjectId",
                table: "Resources",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
