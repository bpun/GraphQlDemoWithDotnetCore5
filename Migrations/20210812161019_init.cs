using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveredStatus = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    DeliveredDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiverName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ContactNo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveredDate", "DeliveredStatus", "OrderedDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(569) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveredDate", "DeliveredStatus", "OrderedDate" },
                values: new object[] { 2, 0, new DateTime(2021, 8, 11, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(3692), "Delivered", new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(4427) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveredDate", "DeliveredStatus", "OrderedDate" },
                values: new object[] { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "Name", "OrderId", "Price", "Quantity" },
                values: new object[] { 1, "IPhone-X", 1, 12m, 2 });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "Name", "OrderId", "Price", "Quantity" },
                values: new object[] { 3, "Redmi", 2, 6m, 5 });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "Name", "OrderId", "Price", "Quantity" },
                values: new object[] { 2, "Oneplus-7", 3, 8m, 3 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Address", "ContactNo", "OrderId", "ReceiverName" },
                values: new object[] { 1, "xyz", "12234444", 1, "Roy" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Address", "ContactNo", "OrderId", "ReceiverName" },
                values: new object[] { 2, "abc", "123422", 2, "Jonny" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Address", "ContactNo", "OrderId", "ReceiverName" },
                values: new object[] { 3, "mno", "17886666", 3, "Pinky" });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrderId",
                table: "LineItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
