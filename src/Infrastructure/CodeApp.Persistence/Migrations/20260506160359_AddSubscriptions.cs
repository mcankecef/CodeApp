using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usersubscriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    provider = table.Column<int>(type: "integer", nullable: false),
                    tier = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    originaltransactionid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    transactionid = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    purchasedateutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiresdateutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastverifiedutc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rawpayload = table.Column<string>(type: "text", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usersubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_usersubscriptions_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_usersubscriptions_provider_originaltransactionid",
                table: "usersubscriptions",
                columns: new[] { "provider", "originaltransactionid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_usersubscriptions_userid",
                table: "usersubscriptions",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usersubscriptions");
        }
    }
}
