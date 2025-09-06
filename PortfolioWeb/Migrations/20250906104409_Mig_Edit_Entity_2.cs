using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWeb.Migrations
{
    /// <inheritdoc />
    public partial class Mig_Edit_Entity_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutSubTitle2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutSubTitle2",
                table: "Abouts");
        }
    }
}
