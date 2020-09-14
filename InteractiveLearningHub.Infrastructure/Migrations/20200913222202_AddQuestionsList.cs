using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningHub.Infrastructure.Migrations
{
    public partial class AddQuestionsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Question_QuestionId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Option_AnswerId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Option_QuestionOptionsId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exams_QuestionId",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuestionOptionsId",
                table: "Questions",
                newName: "IX_Questions_QuestionOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_AnswerId",
                table: "Questions",
                newName: "IX_Questions_AnswerId");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_AnswerId",
                table: "Questions",
                column: "AnswerId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_QuestionOptionsId",
                table: "Questions",
                column: "QuestionOptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_AnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_QuestionOptionsId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuestionOptionsId",
                table: "Question",
                newName: "IX_Question_QuestionOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AnswerId",
                table: "Question",
                newName: "IX_Question_AnswerId");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_QuestionId",
                table: "Exams",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Question_QuestionId",
                table: "Exams",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Option_AnswerId",
                table: "Question",
                column: "AnswerId",
                principalTable: "Option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Option_QuestionOptionsId",
                table: "Question",
                column: "QuestionOptionsId",
                principalTable: "Option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
