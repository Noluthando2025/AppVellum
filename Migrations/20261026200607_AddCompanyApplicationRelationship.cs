using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppVellum.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyApplicationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications");
        }
    }
}
