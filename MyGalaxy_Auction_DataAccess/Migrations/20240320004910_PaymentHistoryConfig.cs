using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGalaxy_Auction_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PaymentHistoryConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "PaymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "PaymentHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 4, 13, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(850), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(853), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(856), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(859), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(862), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(862) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(866), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(868), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(881), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(884), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(887), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(896), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(895) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(899), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(901), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(904), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(907), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(910), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(914), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(913) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 7, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(916), new DateTime(2024, 3, 20, 3, 49, 10, 178, DateTimeKind.Local).AddTicks(916) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "PaymentHistories");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5754), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5742) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5770), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5773), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5772) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5775), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5775) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5778), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5778) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5781), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5781) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5785), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5788), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5791), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5793), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5796), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5799), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5803), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5806), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5808), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5811), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5814), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5817), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5820), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5822), new DateTime(2024, 3, 18, 23, 17, 40, 686, DateTimeKind.Local).AddTicks(5822) });
        }
    }
}
