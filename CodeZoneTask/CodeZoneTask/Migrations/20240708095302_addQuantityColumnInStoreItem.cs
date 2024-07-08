using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeZoneTask.Migrations
{
    /// <inheritdoc />
    public partial class addQuantityColumnInStoreItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "StoreItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StoreItems");
        }
    }
}
