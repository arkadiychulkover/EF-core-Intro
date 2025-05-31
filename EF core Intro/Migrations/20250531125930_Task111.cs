using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core_Intro.Migrations
{
    /// <inheritdoc />
    public partial class Task111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasports_Student_StudentId",
                table: "Pasports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasports");

            migrationBuilder.RenameTable(
                name: "Pasports",
                newName: "Pasport");

            migrationBuilder.RenameIndex(
                name: "IX_Pasports_StudentId",
                table: "Pasport",
                newName: "IX_Pasport_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasport",
                table: "Pasport",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasport",
                sql: "LENGTH(Number) = 9");

            migrationBuilder.AddForeignKey(
                name: "FK_Pasport_Student_StudentId",
                table: "Pasport",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasport_Student_StudentId",
                table: "Pasport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasport",
                table: "Pasport");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasport");

            migrationBuilder.RenameTable(
                name: "Pasport",
                newName: "Pasports");

            migrationBuilder.RenameIndex(
                name: "IX_Pasport_StudentId",
                table: "Pasports",
                newName: "IX_Pasports_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasports",
                sql: "LENGTH([Number]) = 9");

            migrationBuilder.AddForeignKey(
                name: "FK_Pasports_Student_StudentId",
                table: "Pasports",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
