using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningHub.Infrastructure.Migrations
{
    public partial class AddOptionsAndQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "score",
                table: "Exams",
                newName: "Score");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Exams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OptionDescriptorTag = table.Column<int>(nullable: false),
                    OptionContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionOptionsId = table.Column<Guid>(nullable: true),
                    AnswerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Option_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Option_QuestionOptionsId",
                        column: x => x.QuestionOptionsId,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_QuestionId",
                table: "Exams",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AnswerId",
                table: "Question",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionOptionsId",
                table: "Question",
                column: "QuestionOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Question_QuestionId",
                table: "Exams",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Question_QuestionId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropIndex(
                name: "IX_Exams_QuestionId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Exams",
                newName: "score");
        }
    }
}
