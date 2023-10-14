using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingPortal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceToAdvert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Adverts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Adverts");
        }
    }
}
