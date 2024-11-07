using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolar.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurationForAllEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject");

            migrationBuilder.DropIndex(
                name: "IX_InstructorSubject_SubjectId",
                table: "InstructorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_SubjectId",
                table: "DepartmetSubjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject",
                columns: new[] { "SubjectId", "InstructorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                columns: new[] { "SubjectId", "DepartmetId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubject_InstructorId",
                table: "InstructorSubject",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_DepartmetId",
                table: "DepartmetSubjects",
                column: "DepartmetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject");

            migrationBuilder.DropIndex(
                name: "IX_InstructorSubject_InstructorId",
                table: "InstructorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_DepartmetId",
                table: "DepartmetSubjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject",
                columns: new[] { "InstructorId", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                columns: new[] { "DepartmetId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubject_SubjectId",
                table: "InstructorSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_SubjectId",
                table: "DepartmetSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
