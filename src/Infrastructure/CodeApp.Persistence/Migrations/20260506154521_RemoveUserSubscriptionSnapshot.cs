using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserSubscriptionSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "premiumuntilutc",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "subscriptiontier",
                table: "aspnetusers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "premiumuntilutc",
                table: "aspnetusers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subscriptiontier",
                table: "aspnetusers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
