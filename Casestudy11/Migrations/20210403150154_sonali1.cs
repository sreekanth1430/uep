using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Casestudy11.Migrations
{
    public partial class sonali1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "empskillsmodel1",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(nullable: true),
                    skillId = table.Column<int>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Last_updated_Date = table.Column<DateTime>(nullable: false),
                    skill_start_date = table.Column<DateTime>(nullable: false),
                    skill_end_date = table.Column<DateTime>(nullable: false),
                    group = table.Column<string>(nullable: true),
                    skilltype = table.Column<string>(nullable: true),
                    approvedby = table.Column<string>(nullable: true),
                    approveddate = table.Column<string>(nullable: true),
                    primary = table.Column<string>(nullable: true),
                    approval_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empskillsmodel1", x => x.id);
                    table.ForeignKey(
                        name: "FK_empskillsmodel1_EmployeeInfo_empId",
                        column: x => x.empId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empskillsmodel1_SkillMaster_skillId",
                        column: x => x.skillId,
                        principalTable: "SkillMaster",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empskillsmodel1_empId",
                table: "empskillsmodel1",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_empskillsmodel1_skillId",
                table: "empskillsmodel1",
                column: "skillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empskillsmodel1");

            migrationBuilder.CreateTable(
                name: "empskillsmodel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Last_updated_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approval_status = table.Column<int>(type: "int", nullable: false),
                    approvedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approveddate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empId = table.Column<int>(type: "int", nullable: true),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    skillId = table.Column<int>(type: "int", nullable: true),
                    skill_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    skill_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    skilltype = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empskillsmodel", x => x.id);
                    table.ForeignKey(
                        name: "FK_empskillsmodel_EmployeeInfo_empId",
                        column: x => x.empId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empskillsmodel_SkillMaster_skillId",
                        column: x => x.skillId,
                        principalTable: "SkillMaster",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empskillsmodel_empId",
                table: "empskillsmodel",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_empskillsmodel_skillId",
                table: "empskillsmodel",
                column: "skillId");
        }
    }
}
