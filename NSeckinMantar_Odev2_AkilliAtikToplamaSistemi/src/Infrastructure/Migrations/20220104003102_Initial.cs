using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehiclePlate = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "VehicleName", "VehiclePlate" },
                values: new object[] { 1, "Arac1", "06ANK001" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "VehicleName", "VehiclePlate" },
                values: new object[] { 2, "Arac2", "06ANK002" });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "ContainerName", "Latitude", "Longitude", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Cont1Antares", 39.97m, 32.8212m, 1 },
                    { 3, "Cont3AsagiEglence", 39.9721m, 32.8396m, 1 },
                    { 5, "Cont5YenimahKaymakamlik", 32.8121m, 32.811m, 1 },
                    { 7, "Cont7DemetParki", 39.9669m, 32.7971m, 1 },
                    { 2, "Cont2TurgutOzalUni", 39.9721m, 32.8252m, 2 },
                    { 4, "Cont4RagipTParki", 39.9657m, 32.8121m, 2 },
                    { 6, "Cont6IvedikMetro", 39.9576m, 32.8169m, 2 },
                    { 8, "Cont8NazimHikmetKültrMerkezi", 39.9606m, 32.7788m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_VehicleId",
                table: "Containers",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
