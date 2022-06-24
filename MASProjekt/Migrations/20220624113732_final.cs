using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASProjekt.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "Person");

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "Person",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 24, 11, 37, 32, 220, DateTimeKind.Utc).AddTicks(5650), new DateTime(2022, 6, 24, 11, 37, 32, 220, DateTimeKind.Utc).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumns: new[] { "IdGym", "IdPerson" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "ResignationDate", "SignUpDate" },
                values: new object[] { new DateTime(2022, 6, 24, 11, 37, 32, 220, DateTimeKind.Utc).AddTicks(5660), new DateTime(2022, 6, 24, 11, 37, 32, 220, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Birthday", "UniqueNumber" },
                values: new object[] { new DateTime(2022, 6, 24, 11, 37, 32, 220, DateTimeKind.Utc).AddTicks(5670), 602695752 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gyms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6460), new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Agreements",
                keyColumns: new[] { "IdGym", "IdPerson" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "ResignationDate", "SignUpDate" },
                values: new object[] { new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6470), new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Zdrogit");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Birthday", "UniqueNumber" },
                values: new object[] { new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6480), 1061559117 });
        }
    }
}
