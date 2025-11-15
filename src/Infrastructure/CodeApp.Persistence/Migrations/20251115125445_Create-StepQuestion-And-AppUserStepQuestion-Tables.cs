using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    public partial class CreateStepQuestionAndAppUserStepQuestionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create StepQuestions table
            migrationBuilder.CreateTable(
                name: "StepQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepQuestions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create AppUserStepQuestions table
            migrationBuilder.CreateTable(
                name: "AppUserStepQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentStepNumber = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserStepQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserStepQuestions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserStepQuestions_StepQuestions_StepQuestionId",
                        column: x => x.StepQuestionId,
                        principalTable: "StepQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Add StepQuestionId to Questions table (nullable initially)
            migrationBuilder.AddColumn<Guid?>(
                name: "StepQuestionId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true);

            // Create indexes
            migrationBuilder.CreateIndex(
                name: "IX_StepQuestions_LanguageId",
                table: "StepQuestions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStepQuestions_AppUserId",
                table: "AppUserStepQuestions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStepQuestions_StepQuestionId",
                table: "AppUserStepQuestions",
                column: "StepQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StepQuestionId",
                table: "Questions",
                column: "StepQuestionId");

            // Add foreign key constraint from Questions to StepQuestions (nullable)
            migrationBuilder.AddForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions",
                column: "StepQuestionId",
                principalTable: "StepQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions");

            // Drop indexes
            migrationBuilder.DropIndex(
                name: "IX_Questions_StepQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserStepQuestions_StepQuestionId",
                table: "AppUserStepQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserStepQuestions_AppUserId",
                table: "AppUserStepQuestions");

            migrationBuilder.DropIndex(
                name: "IX_StepQuestions_LanguageId",
                table: "StepQuestions");

            // Remove StepQuestionId column from Questions
            migrationBuilder.DropColumn(
                name: "StepQuestionId",
                table: "Questions");

            // Drop tables
            migrationBuilder.DropTable(
                name: "AppUserStepQuestions");

            migrationBuilder.DropTable(
                name: "StepQuestions");
        }
    }
}
