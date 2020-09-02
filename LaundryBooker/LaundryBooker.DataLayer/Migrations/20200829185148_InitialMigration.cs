using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaundryBooker.DataLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    HousePrefix = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaundryRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(nullable: false),
                    RoomStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaundryRooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    SessionStatus = table.Column<string>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    LaundryRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSessions_LaundryRooms_LaundryRoomId",
                        column: x => x.LaundryRoomId,
                        principalTable: "LaundryRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSessions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "HouseNumber", "HousePrefix", "StreetAddress" },
                values: new object[] { 1, 48, "B", "Helenius Gata" });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BuildingId" },
                values: new object[] { 1, 14, 1 });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BuildingId" },
                values: new object[] { 2, 3, 1 });

            migrationBuilder.InsertData(
                table: "LaundryRooms",
                columns: new[] { "Id", "BuildingId", "RoomStatus" },
                values: new object[] { 23, 1, "Free" });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ApartmentId", "Name" },
                values: new object[] { 1, 1, "Calle" });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ApartmentId", "Name" },
                values: new object[] { 2, 2, "Erik" });

            migrationBuilder.InsertData(
                table: "BookingSessions",
                columns: new[] { "Id", "EndTime", "LaundryRoomId", "SessionStatus", "StartTime", "TenantId" },
                values: new object[] { new Guid("0306d7f7-b0ca-4937-950a-6f73e278792b"), new DateTimeOffset(new DateTime(2020, 6, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 23, "Finished", new DateTimeOffset(new DateTime(2020, 6, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 });

            migrationBuilder.InsertData(
                table: "BookingSessions",
                columns: new[] { "Id", "EndTime", "LaundryRoomId", "SessionStatus", "StartTime", "TenantId" },
                values: new object[] { new Guid("09dd120c-286b-4891-a8df-7cd616dd65cb"), new DateTimeOffset(new DateTime(2020, 6, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 23, "Scheduled", new DateTimeOffset(new DateTime(2020, 6, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1 });

            migrationBuilder.InsertData(
                table: "BookingSessions",
                columns: new[] { "Id", "EndTime", "LaundryRoomId", "SessionStatus", "StartTime", "TenantId" },
                values: new object[] { new Guid("23e00cbf-7a2e-43ee-8a7a-6b21eb4513d4"), new DateTimeOffset(new DateTime(2020, 7, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 23, "Scheduled", new DateTimeOffset(new DateTime(2020, 7, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BuildingId",
                table: "Apartments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSessions_LaundryRoomId",
                table: "BookingSessions",
                column: "LaundryRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSessions_TenantId",
                table: "BookingSessions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LaundryRooms_BuildingId",
                table: "LaundryRooms",
                column: "BuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApartmentId",
                table: "Tenants",
                column: "ApartmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSessions");

            migrationBuilder.DropTable(
                name: "LaundryRooms");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
