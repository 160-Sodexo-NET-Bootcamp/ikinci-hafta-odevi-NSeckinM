using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "ContainerName", "Latitude", "Longitude", "VehicleId" },
                values: new object[] { 17, "Cont17Mithatpasa", 39.920155m, 32.858952m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Containers",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
