using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiteCareers.Data.Migrations
{
    /// <inheritdoc />
    public partial class questionsandresponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "response",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "UserDescriptions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "interviewId",
                table: "Sessions",
                newName: "InterviewId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Sessions",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Responses",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "responseId",
                table: "Responses",
                newName: "ResponseId");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "question",
                table: "Questions",
                newName: "QuestionContent");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Interviews",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "interviewId",
                table: "Interviews",
                newName: "InterviewId");

            migrationBuilder.AddColumn<string>(
                name: "UserResponse",
                table: "Responses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserResponse",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "UserDescriptions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "InterviewId",
                table: "Sessions",
                newName: "interviewId");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Sessions",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Responses",
                newName: "questionId");

            migrationBuilder.RenameColumn(
                name: "ResponseId",
                table: "Responses",
                newName: "responseId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "questionId");

            migrationBuilder.RenameColumn(
                name: "QuestionContent",
                table: "Questions",
                newName: "question");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Interviews",
                newName: "questionId");

            migrationBuilder.RenameColumn(
                name: "InterviewId",
                table: "Interviews",
                newName: "interviewId");

            migrationBuilder.AddColumn<int>(
                name: "response",
                table: "Responses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
