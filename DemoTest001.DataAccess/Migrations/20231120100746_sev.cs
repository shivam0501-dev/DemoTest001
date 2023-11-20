using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTest001.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "states",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryID",
                table: "states",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_states_countries_CountryID",
                table: "states",
                column: "CountryID",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_states_countries_CountryID",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_CountryID",
                table: "states");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "states");
        }
    }
}
