using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    IdMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.IdMember);
                    table.ForeignKey(
                        name: "FK_Member_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                    table.ForeignKey(
                        name: "FK_Team_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    IdFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_File_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    IdMember = table.Column<int>(type: "int", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamIdTeam = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShip", x => new { x.IdMember, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_MemberShip_Member_IdMember",
                        column: x => x.IdMember,
                        principalTable: "Member",
                        principalColumn: "IdMember",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberShip_Team_TeamIdTeam",
                        column: x => x.TeamIdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Domain", "Name" },
                values: new object[] { 1, "sssss", "dddd" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "IdMember", "IdOrganization", "Name", "NickName", "Surname" },
                values: new object[] { 1, 1, "aaaaa", "ssss", "fffff" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "IdTeam", "Description", "IdOrganization", "TeamName" },
                values: new object[] { 1, "asadasdaf", 1, "zzzzz" });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "IdFile", "FileExtension", "FileName", "FileSize", "IdTeam" },
                values: new object[] { 1, "jpg", "xxx", 2, 1 });

            migrationBuilder.InsertData(
                table: "MemberShip",
                columns: new[] { "IdMember", "IdTeam", "MembershipDate", "TeamIdTeam" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.CreateIndex(
                name: "IX_File_IdTeam",
                table: "File",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Member_IdOrganization",
                table: "Member",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShip_TeamIdTeam",
                table: "MemberShip",
                column: "TeamIdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdOrganization",
                table: "Team",
                column: "IdOrganization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
