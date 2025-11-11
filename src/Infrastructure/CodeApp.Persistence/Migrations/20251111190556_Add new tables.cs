using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    public partial class Addnewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StepQuestionId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Avatars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenEndDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

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
                });

            migrationBuilder.CreateTable(
                name: "AppUserStepQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentStepNumber = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserStepQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserStepQuestions_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserStepQuestions_StepQuestions_StepQuestionId",
                        column: x => x.StepQuestionId,
                        principalTable: "StepQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_StepQuestionId",
                table: "Questions",
                column: "StepQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStepQuestions_AppUserId1",
                table: "AppUserStepQuestions",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStepQuestions_StepQuestionId",
                table: "AppUserStepQuestions",
                column: "StepQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions",
                column: "StepQuestionId",
                principalTable: "StepQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_StepQuestions_StepQuestionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "AppUserStepQuestions");

            migrationBuilder.DropTable(
                name: "StepQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_StepQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "StepQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenEndDate",
                table: "AspNetUsers");
        }
    }
}
