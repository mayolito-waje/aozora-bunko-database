using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    SurnameReading = table.Column<string>(type: "TEXT", nullable: true),
                    SurnameSort = table.Column<string>(type: "TEXT", nullable: true),
                    SurnameRomaji = table.Column<string>(type: "TEXT", nullable: true),
                    GivenName = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameReading = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameSort = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameRomaji = table.Column<string>(type: "TEXT", nullable: true),
                    RoleFlag = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    DeathDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    PersonalityRights = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
