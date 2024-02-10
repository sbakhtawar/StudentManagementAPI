using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vpsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 15, 56, 44, 839, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 15, 56, 44, 839, DateTimeKind.Local).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 15, 56, 44, 839, DateTimeKind.Local).AddTicks(8976));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 4, 17, 21, 43, 930, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 4, 17, 21, 43, 930, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 4, 17, 21, 43, 930, DateTimeKind.Local).AddTicks(7724));
        }
    }
}
