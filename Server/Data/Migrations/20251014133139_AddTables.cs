using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    SurnameReading = table.Column<string>(type: "TEXT", nullable: false),
                    SurnameSort = table.Column<string>(type: "TEXT", nullable: false),
                    SurnameRomaji = table.Column<string>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameReading = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameSort = table.Column<string>(type: "TEXT", nullable: true),
                    GivenNameRomaji = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    DeathDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    PersonalityRights = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WriterRoles",
                columns: table => new
                {
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterRoles", x => x.Role);
                });

            migrationBuilder.CreateTable(
                name: "WritingStyles",
                columns: table => new
                {
                    Style = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingStyles", x => x.Style);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<string>(type: "TEXT", nullable: true),
                    PublishDateInfo = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalSourceId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sources_Sources_OriginalSourceId",
                        column: x => x.OriginalSourceId,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WrittenWorks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    TitleReading = table.Column<string>(type: "TEXT", nullable: false),
                    TitleSort = table.Column<string>(type: "TEXT", nullable: false),
                    Subtitle = table.Column<string>(type: "TEXT", nullable: true),
                    SubtitleReading = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseInfo = table.Column<string>(type: "TEXT", nullable: true),
                    WritingStyleId = table.Column<string>(type: "TEXT", nullable: false),
                    WorkCopyright = table.Column<bool>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: false),
                    WriterRoleId = table.Column<string>(type: "TEXT", nullable: false),
                    SourceId = table.Column<string>(type: "TEXT", nullable: true),
                    Source2Id = table.Column<string>(type: "TEXT", nullable: true),
                    TextLink = table.Column<string>(type: "TEXT", nullable: false),
                    HTMLLink = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_Sources_Source2Id",
                        column: x => x.Source2Id,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_WriterRoles_WriterRoleId",
                        column: x => x.WriterRoleId,
                        principalTable: "WriterRoles",
                        principalColumn: "Role",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenWorks_WritingStyles_WritingStyleId",
                        column: x => x.WritingStyleId,
                        principalTable: "WritingStyles",
                        principalColumn: "Style",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_OriginalSourceId",
                table: "Sources",
                column: "OriginalSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_PublisherId",
                table: "Sources",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_AuthorId",
                table: "WrittenWorks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_Source2Id",
                table: "WrittenWorks",
                column: "Source2Id");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_SourceId",
                table: "WrittenWorks",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_WriterRoleId",
                table: "WrittenWorks",
                column: "WriterRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_WritingStyleId",
                table: "WrittenWorks",
                column: "WritingStyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WrittenWorks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "WriterRoles");

            migrationBuilder.DropTable(
                name: "WritingStyles");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
