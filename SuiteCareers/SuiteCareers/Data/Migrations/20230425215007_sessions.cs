using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    /// <inheritdoc />
    public partial class sessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Sessions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "sessionId",
                table: "Sessions",
                newName: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sessions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Sessions",
                newName: "sessionId");
        }
    }
}
