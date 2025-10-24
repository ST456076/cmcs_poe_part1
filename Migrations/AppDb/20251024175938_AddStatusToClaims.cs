using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cmcs_poe_part1.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class AddStatusToClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Claims");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Claims");

            migrationBuilder.AddColumn<double>(
                name: "Description",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
