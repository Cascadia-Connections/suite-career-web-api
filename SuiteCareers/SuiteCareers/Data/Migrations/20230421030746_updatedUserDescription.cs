using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedUserDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserDescriptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDescriptions");
        }
    }
}
