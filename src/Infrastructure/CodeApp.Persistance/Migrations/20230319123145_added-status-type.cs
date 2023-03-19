using System;
using CodeApp.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistance.Migrations
{
    public partial class addedstatustype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Languages",
                nullable:true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Questions",
                nullable:true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Subjects",
                nullable:true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Answers",
                nullable:true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
