using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IleriWebFinalProjesi.Migrations
{
    /// <inheritdoc />
    public partial class islem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieDataId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MovieType",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieDataId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MovieType",
                table: "Comments");
        }
    }
}
