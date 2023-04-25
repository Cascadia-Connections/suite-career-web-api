using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    /// <inheritdoc />
    public partial class interviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Interviews");

            migrationBuilder.AddColumn<long>(
                name: "InterviewId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_InterviewId",
                table: "Questions",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Interviews_InterviewId",
                table: "Questions",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "InterviewId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Interviews_InterviewId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_InterviewId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Interviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
