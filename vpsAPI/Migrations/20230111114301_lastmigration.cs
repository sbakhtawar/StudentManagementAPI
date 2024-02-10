using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vpsAPI.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 43, 1, 53, DateTimeKind.Local).AddTicks(8516));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 32, 0, 156, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 32, 0, 156, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 32, 0, 156, DateTimeKind.Local).AddTicks(6782));
        }
    }
}
