using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistance.Migrations
{
    public partial class addedrelationshipbetweenlanguageandsubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LanguageId",
                table: "Subjects",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Languages_LanguageId",
                table: "Subjects",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Languages_LanguageId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_LanguageId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Subjects");
        }
    }
}
