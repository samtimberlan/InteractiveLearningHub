using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningHub.Infrastructure.Migrations
{
    public partial class AddCourseModifiedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Courses");
        }
    }
}
