using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistence.Migrations
{
    public partial class Baseline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Bu migration mevcut veritabanının baseline'ını temsil ediyor
            // Tablolar zaten mevcut, bu yüzden hiçbir şey yapmıyoruz
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Baseline migration için rollback tanımlanmamış
        }
    }
}
