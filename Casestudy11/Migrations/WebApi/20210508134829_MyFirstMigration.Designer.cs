// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using casestudy11.Data;

namespace Casestudy11.Migrations.WebApi
{
    [DbContext(typeof(WebApiContext))]
    [Migration("20210508134829_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Casestudy11.Model.EmployeeInfo", b =>
                {
                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<string>("empEmailId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("empName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("grade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("hccOrganization")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("pmEmailId")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("pmIdempId")
                        .HasColumnType("int");

                    b.Property<string>("project")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("role")
                        .HasColumnType("varchar(60)");

                    b.HasKey("empId");

                    b.HasIndex("pmIdempId");

                    b.ToTable("EmployeeInfo");
                });

            modelBuilder.Entity("Casestudy11.Model.EmployeeSkill", b =>
                {
                    b.Property<int>("pkAuto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<string>("approvedBy")
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime?>("approvedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("empId1")
                        .HasColumnType("int");

                    b.Property<string>("empName")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("grade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("group")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("hccOrganization")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("lastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("primary")
                        .HasColumnType("int");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("skillEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("skillId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("skillStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("skillType")
                        .HasColumnType("varchar(25)");

                    b.HasKey("pkAuto");

                    b.HasIndex("empId1");

                    b.HasIndex("skillId");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("Casestudy11.Model.SkillMaster", b =>
                {
                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("skillCatName")
                        .HasColumnType("varchar(500)");

                    b.HasKey("skillId");

                    b.ToTable("SkillMaster");
                });

            modelBuilder.Entity("Casestudy11.Model.EmployeeInfo", b =>
                {
                    b.HasOne("Casestudy11.Model.EmployeeInfo", "pmId")
                        .WithMany()
                        .HasForeignKey("pmIdempId");
                });

            modelBuilder.Entity("Casestudy11.Model.EmployeeSkill", b =>
                {
                    b.HasOne("Casestudy11.Model.EmployeeInfo", "empId")
                        .WithMany()
                        .HasForeignKey("empId1");

                    b.HasOne("Casestudy11.Model.SkillMaster", "SkillId")
                        .WithMany()
                        .HasForeignKey("skillId");
                });
#pragma warning restore 612, 618
        }
    }
}
