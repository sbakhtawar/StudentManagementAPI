using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vpsAPI.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 44, 38, 490, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 44, 38, 490, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 44, 38, 490, DateTimeKind.Local).AddTicks(3944));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(893));
        }
    }
}
