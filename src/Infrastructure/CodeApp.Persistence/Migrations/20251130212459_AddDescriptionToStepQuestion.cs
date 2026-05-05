using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToStepQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StepQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StepQuestions");
        }
    }
}
