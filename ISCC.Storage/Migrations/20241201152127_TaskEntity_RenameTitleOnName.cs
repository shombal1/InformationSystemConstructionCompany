using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCC.Storage.Migrations
{
    /// <inheritdoc />
    public partial class TaskEntity_RenameTitleOnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "Title");
        }
    }
}
