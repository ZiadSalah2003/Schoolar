using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolar.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DID",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DID",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentNameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "DID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_DID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DID",
                table: "Students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
