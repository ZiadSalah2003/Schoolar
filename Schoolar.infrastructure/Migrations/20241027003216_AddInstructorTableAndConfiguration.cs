using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolar.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorTableAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Departments_DID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubID",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_SubID",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_DID",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_SubID",
                table: "DepartmetSubjects");

            migrationBuilder.DropColumn(
                name: "StudentSubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "SubID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "DepartmetSubjectId",
                table: "DepartmetSubjects");

            migrationBuilder.DropColumn(
                name: "DID",
                table: "DepartmetSubjects");

            migrationBuilder.DropColumn(
                name: "SubID",
                table: "DepartmetSubjects");

            migrationBuilder.AddColumn<int>(
                name: "InsManager",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorManger",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                columns: new[] { "DepartmetId", "SubjectId" });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructor_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSubject",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSubject", x => new { x.InstructorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_InstructorSubject_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_SubjectId",
                table: "DepartmetSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsManager",
                table: "Departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentId",
                table: "Instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSubject_SubjectId",
                table: "InstructorSubject",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Departments_DepartmetId",
                table: "DepartmetSubjects",
                column: "DepartmetId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubjectId",
                table: "DepartmetSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Departments_DepartmetId",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubjectId",
                table: "DepartmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "InstructorSubject");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmetSubjects_SubjectId",
                table: "DepartmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsManager",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InsManager",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InstructorManger",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjectId",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudID",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubID",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmetSubjectId",
                table: "DepartmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DID",
                table: "DepartmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubID",
                table: "DepartmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjects",
                table: "StudentSubjects",
                column: "StudentSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubjects",
                table: "DepartmetSubjects",
                column: "DepartmetSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudID",
                table: "StudentSubjects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubID",
                table: "StudentSubjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_DID",
                table: "DepartmetSubjects",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmetSubjects_SubID",
                table: "DepartmetSubjects",
                column: "SubID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Departments_DID",
                table: "DepartmetSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubjects_Subjects_SubID",
                table: "DepartmetSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudID",
                table: "StudentSubjects",
                column: "StudID",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubID",
                table: "StudentSubjects",
                column: "SubID",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
