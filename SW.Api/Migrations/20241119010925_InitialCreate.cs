using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false),
                    UserAccountType = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCommend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SleepQualityStatus = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "(N'Admin')"),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'User')"),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData_3214EC076D7D9088", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataDream",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserDataId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SleepQualityStatus = table.Column<short>(type: "smallint", nullable: false),
                    AverageHearthRate = table.Column<int>(type: "int", nullable: true),
                    AverageOxygenLevel = table.Column<double>(type: "float", nullable: true),
                    DeepSleepHours = table.Column<double>(type: "float", nullable: true),
                    Interruptions = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'Admin')"),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataDream_UserData",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccountUserData",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    UserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountUserData", x => new { x.UserAccountId, x.UserDataId });
                    table.ForeignKey(
                        name: "FK_UserAccountUserData_UserAccount",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccountUserData_UserData",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDataCommend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDataId = table.Column<int>(type: "int", nullable: false),
                    UserCommendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserDataCommend__3214EC07A20A3AD6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDataCommend_UserComment",
                        column: x => x.UserCommendId,
                        principalTable: "UserCommend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDataCommend_UserData",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataDream_UserDataId",
                table: "DataDream",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountUserData_UserDataId",
                table: "UserAccountUserData",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataCommend_UserCommendId",
                table: "UserDataCommend",
                column: "UserCommendId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataCommend_UserDataId",
                table: "UserDataCommend",
                column: "UserDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDream");

            migrationBuilder.DropTable(
                name: "UserAccountUserData");

            migrationBuilder.DropTable(
                name: "UserDataCommend");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "UserCommend");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
