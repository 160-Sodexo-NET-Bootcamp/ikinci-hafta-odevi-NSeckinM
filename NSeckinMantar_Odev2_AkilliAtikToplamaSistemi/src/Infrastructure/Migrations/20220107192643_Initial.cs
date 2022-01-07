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
                    Latitude = table.Column<decimal>(type: "decimal(10,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10,6)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
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
                    { 9, "Cont9Ankamall", 39.951862m, 32.832848m, 1 },
                    { 11, "Cont11Kugulupark", 39.902428m, 32.860600m, 1 },
                    { 13, "Cont13GenlikParki", 39.936897m, 32.853897m, 1 },
                    { 15, "Cont15Kizilay", 39.9213m, 32.8506m, 1 },
                    { 2, "Cont2TurgutOzalUni", 39.9721m, 32.8252m, 2 },
                    { 4, "Cont4RagipTParki", 39.9657m, 32.8121m, 2 },
                    { 6, "Cont6IvedikMetro", 39.9576m, 32.8169m, 2 },
                    { 8, "Cont8NazimHikmetKültrMerkezi", 39.9606m, 32.7788m, 2 },
                    { 10, "Cont10tunalı", 39.909115m, 32.861881m, 2 },
                    { 12, "Cont12Ulus", 39.941757m, 32.854733m, 2 },
                    { 14, "Cont14Sihhiye", 39.929447m, 32.854996m, 2 },
                    { 16, "Cont16Guvenpark", 39.919548m, 32.853199m, 2 }
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
