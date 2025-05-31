using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core_Intro.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Scolarship",
                table: "Student",
                type: "decimal(6, 2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Student",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "StudyFormat",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_Email",
                table: "Student",
                sql: "[Email] Like '%@%.%'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_StudyFormat",
                table: "Student",
                sql: "[StudyFormat] IN ('FullTime', 'PartTime', 'Online', 'Gibrid')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_Email",
                table: "Student");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_StudyFormat",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudyFormat",
                table: "Student");

            migrationBuilder.AlterColumn<float>(
                name: "Scolarship",
                table: "Student",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "decimal(6, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
