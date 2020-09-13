using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningHub.Infrastructure.Migrations
{
    public partial class AddCourseContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Courses");
        }
    }
}
