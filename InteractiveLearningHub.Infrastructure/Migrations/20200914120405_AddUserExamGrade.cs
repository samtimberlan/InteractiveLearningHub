using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningHub.Infrastructure.Migrations
{
    public partial class AddUserExamGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Courses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "ApplicationUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserExamGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamGrades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExamGrades");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityUserId",
                table: "ApplicationUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
