using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Casestudy11.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false),
                    empName = table.Column<string>(type: "varchar(100)", nullable: true),
                    empEmailId = table.Column<string>(type: "varchar(100)", nullable: true),
                    project = table.Column<string>(type: "varchar(100)", nullable: true),
                    pmIdempId = table.Column<int>(nullable: true),
                    pmEmailId = table.Column<string>(type: "varchar(100)", nullable: true),
                    role = table.Column<string>(type: "varchar(60)", nullable: true),
                    grade = table.Column<string>(type: "varchar(100)", nullable: true),
                    hccOrganization = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfo", x => x.empId);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_EmployeeInfo_pmIdempId",
                        column: x => x.pmIdempId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillMaster",
                columns: table => new
                {
                    skillId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(500)", nullable: true),
                    skillCatName = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMaster", x => x.skillId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    pkAuto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primary = table.Column<int>(nullable: false),
                    empId1 = table.Column<int>(nullable: true),
                    empName = table.Column<string>(type: "varchar(45)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    hccOrganization = table.Column<string>(type: "varchar(150)", nullable: true),
                    grade = table.Column<string>(type: "varchar(100)", nullable: true),
                    lastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    skillStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    skillEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    group = table.Column<string>(type: "varchar(150)", nullable: true),
                    skillType = table.Column<string>(type: "varchar(25)", nullable: true),
                    approvedBy = table.Column<string>(type: "varchar(45)", nullable: true),
                    approvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    skillId = table.Column<int>(nullable: true),
                    approvalStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.pkAuto);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_EmployeeInfo_empId1",
                        column: x => x.empId1,
                        principalTable: "EmployeeInfo",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_SkillMaster_skillId",
                        column: x => x.skillId,
                        principalTable: "SkillMaster",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_pmIdempId",
                table: "EmployeeInfo",
                column: "pmIdempId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_empId1",
                table: "EmployeeSkills",
                column: "empId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_skillId",
                table: "EmployeeSkills",
                column: "skillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeInfo");

            migrationBuilder.DropTable(
                name: "SkillMaster");
        }
    }
}
