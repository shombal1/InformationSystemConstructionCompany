using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTaskEntity_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTaskEntity_Projects_ProjectId",
                table: "GroupTaskEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_GroupTaskEntity_GroupId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTaskEntity",
                table: "GroupTaskEntity");

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: new Guid("f82901e1-7e54-4fb7-82c7-130d76e9faa4"));

            migrationBuilder.RenameTable(
                name: "GroupTaskEntity",
                newName: "GroupTasks");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTaskEntity_ProjectId",
                table: "GroupTasks",
                newName: "IX_GroupTasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTaskEntity_ParentGroupId",
                table: "GroupTasks",
                newName: "IX_GroupTasks_ParentGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTasks",
                table: "GroupTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTasks_GroupTasks_ParentGroupId",
                table: "GroupTasks",
                column: "ParentGroupId",
                principalTable: "GroupTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTasks_Projects_ProjectId",
                table: "GroupTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_GroupTasks_GroupId",
                table: "Tasks",
                column: "GroupId",
                principalTable: "GroupTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTasks_GroupTasks_ParentGroupId",
                table: "GroupTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTasks_Projects_ProjectId",
                table: "GroupTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_GroupTasks_GroupId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTasks",
                table: "GroupTasks");

            migrationBuilder.RenameTable(
                name: "GroupTasks",
                newName: "GroupTaskEntity");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTasks_ProjectId",
                table: "GroupTaskEntity",
                newName: "IX_GroupTaskEntity_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTasks_ParentGroupId",
                table: "GroupTaskEntity",
                newName: "IX_GroupTaskEntity_ParentGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTaskEntity",
                table: "GroupTaskEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f82901e1-7e54-4fb7-82c7-130d76e9faa4"), "шт" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTaskEntity_GroupTaskEntity_ParentGroupId",
                table: "GroupTaskEntity",
                column: "ParentGroupId",
                principalTable: "GroupTaskEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTaskEntity_Projects_ProjectId",
                table: "GroupTaskEntity",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_GroupTaskEntity_GroupId",
                table: "Tasks",
                column: "GroupId",
                principalTable: "GroupTaskEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
