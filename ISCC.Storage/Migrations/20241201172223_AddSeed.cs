using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f82901e1-7e54-4fb7-82c7-130d76e9faa4"), "шт" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: new Guid("f82901e1-7e54-4fb7-82c7-130d76e9faa4"));
        }
    }
}
