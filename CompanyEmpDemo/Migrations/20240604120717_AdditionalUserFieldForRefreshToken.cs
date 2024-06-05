using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmpDemo.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFieldForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68563157-e351-41ed-a7be-3208efab7169");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bb139e3-2282-4020-9f04-3ca908578e79");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("2af884bd-b406-4eab-b4d5-e512863f6791"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7068bd76-2934-4c79-bbb8-281647c9b70a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9614d68b-104d-41e9-bed6-e27dda1d990a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9c6fc155-00c8-4137-9303-e5c6f04fbd02"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a64685ec-0aa1-41a6-be53-f7db2de257d6", "b12b6fe9-2628-42f5-87d6-1de84470d4e3", "Administrator", "ADMINISTRATOR" },
                    { "e104dd3d-49a3-4a93-a43e-b9a73588b9b4", "7f0f53f4-404e-478c-a804-4f6a7fa36a28", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("123bf814-56e2-456b-963c-fe2790a7053c"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Pawan Rajput", "UnityDeveloper" },
                    { new Guid("25c8dd66-44eb-4e9e-ba22-41c6267f3c9f"), 28, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Rahul Tripathi", "Administrator" },
                    { new Guid("5f197126-6781-450a-bfdc-10941a53122e"), 34, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Denish Makadiya", "Sr. UnityDeveloper" },
                    { new Guid("e2908c3d-bc26-4d40-8cb4-7378e71dfd48"), 25, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sachin Tomar", "Frontend Developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a64685ec-0aa1-41a6-be53-f7db2de257d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e104dd3d-49a3-4a93-a43e-b9a73588b9b4");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("123bf814-56e2-456b-963c-fe2790a7053c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("25c8dd66-44eb-4e9e-ba22-41c6267f3c9f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5f197126-6781-450a-bfdc-10941a53122e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e2908c3d-bc26-4d40-8cb4-7378e71dfd48"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68563157-e351-41ed-a7be-3208efab7169", "e9384ace-24c4-4709-9acb-e228c61e5987", "Manager", "MANAGER" },
                    { "6bb139e3-2282-4020-9f04-3ca908578e79", "208f609a-80d0-48a6-9e29-cabad14ea53a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("2af884bd-b406-4eab-b4d5-e512863f6791"), 28, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Rahul Tripathi", "Administrator" },
                    { new Guid("7068bd76-2934-4c79-bbb8-281647c9b70a"), 34, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Denish Makadiya", "Sr. UnityDeveloper" },
                    { new Guid("9614d68b-104d-41e9-bed6-e27dda1d990a"), 25, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sachin Tomar", "Frontend Developer" },
                    { new Guid("9c6fc155-00c8-4137-9303-e5c6f04fbd02"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Pawan Rajput", "UnityDeveloper" }
                });
        }
    }
}
