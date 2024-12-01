using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddingMultiLevelGrouping_GroupTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentGroupId",
                table: "GroupTaskEntity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity",
                column: "ParentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTaskEntity_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity",
                column: "ParentGroupId",
                principalTable: "GroupTaskEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTaskEntity_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity");

            migrationBuilder.DropIndex(
                name: "IX_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity");

            migrationBuilder.DropColumn(
                name: "ParentGroupId",
                table: "GroupTaskEntity");
        }
    }
}
