using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core_Intro.Migrations
{
    /// <inheritdoc />
    public partial class Task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasports_Student_StudentId",
                table: "Pasports");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Groups_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Subjects_SubjectsId",
                table: "TeachersSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Teachers_TeachersId",
                table: "TeachersSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Pasports_StudentId",
                table: "Pasports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafedras",
                table: "Cafedras");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Cafedras",
                newName: "Cafedra");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CafedraId",
                table: "Teacher",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Teacher",
                type: "decimal(8, 2)",
                nullable: false,
                defaultValue: 25000);

            migrationBuilder.AddColumn<int>(
                name: "CafedraId",
                table: "Subject",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafedra",
                table: "Cafedra",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Email",
                table: "Student",
                column: "Email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasports",
                sql: "LENGTH([Number]) = 9");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CafedraId",
                table: "Teacher",
                column: "CafedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CafedraId",
                table: "Subject",
                column: "CafedraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Pasports_Id",
                table: "Student",
                column: "Id",
                principalTable: "Pasports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Cafedra_CafedraId",
                table: "Subject",
                column: "CafedraId",
                principalTable: "Cafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Cafedra_CafedraId",
                table: "Teacher",
                column: "CafedraId",
                principalTable: "Cafedra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Subject_SubjectsId",
                table: "TeachersSubjects",
                column: "SubjectsId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Teacher_TeachersId",
                table: "TeachersSubjects",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Pasports_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Cafedra_CafedraId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Cafedra_CafedraId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Subject_SubjectsId",
                table: "TeachersSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSubjects_Teacher_TeachersId",
                table: "TeachersSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Student_Email",
                table: "Student");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Pasport_Number",
                table: "Pasports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_CafedraId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CafedraId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafedra",
                table: "Cafedra");

            migrationBuilder.DropColumn(
                name: "CafedraId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "CafedraId",
                table: "Subject");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Cafedra",
                newName: "Cafedras");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafedras",
                table: "Cafedras",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Groups_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Subjects_SubjectsId",
                table: "TeachersSubjects",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSubjects_Teachers_TeachersId",
                table: "TeachersSubjects",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
