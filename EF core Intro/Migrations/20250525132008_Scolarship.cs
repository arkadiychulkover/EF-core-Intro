using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core_Intro.Migrations
{
    /// <inheritdoc />
    public partial class Scolarship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Scolarship",
                table: "Students",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scolarship",
                table: "Students");
        }
    }
}
