﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SW.Infrastructure.Data;

#nullable disable

namespace SW.Api.Migrations
{
    [DbContext(typeof(SWDbContext))]
    [Migration("20241119010925_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SW.Domain.Entities.ActiveUserAccount", b =>
                {
                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("UserAccountId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short>("UserAccountType")
                        .HasColumnType("smallint");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.ToTable((string)null);

                    b.ToView("VW_ActiveUserAccount", (string)null);
                });

            modelBuilder.Entity("SW.Domain.Entities.DataDream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AverageHearthRate")
                        .HasColumnType("int");

                    b.Property<double?>("AverageOxygenLevel")
                        .HasColumnType("float");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("(N'Admin')");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<double?>("DeepSleepHours")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("Interruptions")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("SleepQualityStatus")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId");

                    b.ToTable("DataDream");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAuthorized")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("UserAccountType")
                        .HasColumnType("smallint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserCommend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValueSql("(N'Admin')");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<short>("SleepQualityStatus")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("UserCommend");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("(N'User')");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<short?>("Gender")
                        .HasColumnType("smallint");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_UserData_3214EC076D7D9088");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserDataCommend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserCommendId")
                        .HasColumnType("int");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__UserDataCommend__3214EC07A20A3AD6");

                    b.HasIndex("UserCommendId");

                    b.HasIndex("UserDataId");

                    b.ToTable("UserDataCommend");
                });

            modelBuilder.Entity("UserAccountUserData", b =>
                {
                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("UserAccountId", "UserDataId");

                    b.HasIndex("UserDataId");

                    b.ToTable("UserAccountUserData");
                });

            modelBuilder.Entity("SW.Domain.Entities.DataDream", b =>
                {
                    b.HasOne("SW.Domain.Entities.UserData", "UserData")
                        .WithMany("DataDream")
                        .HasForeignKey("UserDataId")
                        .IsRequired()
                        .HasConstraintName("FK_DataDream_UserData");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserDataCommend", b =>
                {
                    b.HasOne("SW.Domain.Entities.UserCommend", "UserCommend")
                        .WithMany("UserDataCommend")
                        .HasForeignKey("UserCommendId")
                        .IsRequired()
                        .HasConstraintName("FK_UserDataCommend_UserComment");

                    b.HasOne("SW.Domain.Entities.UserData", "UserData")
                        .WithMany("UserDataCommend")
                        .HasForeignKey("UserDataId")
                        .IsRequired()
                        .HasConstraintName("FK_UserDataCommend_UserData");

                    b.Navigation("UserCommend");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("UserAccountUserData", b =>
                {
                    b.HasOne("SW.Domain.Entities.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .IsRequired()
                        .HasConstraintName("FK_UserAccountUserData_UserAccount");

                    b.HasOne("SW.Domain.Entities.UserData", null)
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .IsRequired()
                        .HasConstraintName("FK_UserAccountUserData_UserData");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserCommend", b =>
                {
                    b.Navigation("UserDataCommend");
                });

            modelBuilder.Entity("SW.Domain.Entities.UserData", b =>
                {
                    b.Navigation("DataDream");

                    b.Navigation("UserDataCommend");
                });
#pragma warning restore 612, 618
        }
    }
}
