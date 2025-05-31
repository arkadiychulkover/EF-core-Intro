using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core_Intro.Migrations
{
    /// <inheritdoc />
    public partial class Task11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Pasports_Id",
                table: "Student");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Teacher",
                type: "decimal(8, 2)",
                nullable: false,
                defaultValue: 25000m,
                oldClrType: typeof(int),
                oldType: "decimal(8, 2)",
                oldDefaultValue: 25000);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_StudentId",
                table: "Pasports",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pasports_Student_StudentId",
                table: "Pasports",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasports_Student_StudentId",
                table: "Pasports");

            migrationBuilder.DropIndex(
                name: "IX_Pasports_StudentId",
                table: "Pasports");

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Teacher",
                type: "decimal(8, 2)",
                nullable: false,
                defaultValue: 25000,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)",
                oldDefaultValue: 25000m);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Pasports_Id",
                table: "Student",
                column: "Id",
                principalTable: "Pasports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
