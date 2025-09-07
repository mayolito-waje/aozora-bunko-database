using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WrittenWorks_Sources_底本ID",
                table: "WrittenWorks");

            migrationBuilder.AddColumn<string>(
                name: "底本2ID",
                table: "WrittenWorks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WrittenWorks_底本2ID",
                table: "WrittenWorks",
                column: "底本2ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WrittenWorks_Sources_底本2ID",
                table: "WrittenWorks",
                column: "底本2ID",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WrittenWorks_Sources_底本ID",
                table: "WrittenWorks",
                column: "底本ID",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WrittenWorks_Sources_底本2ID",
                table: "WrittenWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_WrittenWorks_Sources_底本ID",
                table: "WrittenWorks");

            migrationBuilder.DropIndex(
                name: "IX_WrittenWorks_底本2ID",
                table: "WrittenWorks");

            migrationBuilder.DropColumn(
                name: "底本2ID",
                table: "WrittenWorks");

            migrationBuilder.AddForeignKey(
                name: "FK_WrittenWorks_Sources_底本ID",
                table: "WrittenWorks",
                column: "底本ID",
                principalTable: "Sources",
                principalColumn: "Id");
        }
    }
}
