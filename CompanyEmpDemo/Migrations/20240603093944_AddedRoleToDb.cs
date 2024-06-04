using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmpDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("13c15614-4351-4957-9b44-18d197dcc230"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("2ac9566e-7846-4f4f-917e-293e5057ebd1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7f8320fd-b16d-4565-a596-4b1515eb94a2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c769e243-8dc9-48c9-8520-39220fff94f6"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("13c15614-4351-4957-9b44-18d197dcc230"), 34, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Denish Makadiya", "Sr. UnityDeveloper" },
                    { new Guid("2ac9566e-7846-4f4f-917e-293e5057ebd1"), 28, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Rahul Tripathi", "Administrator" },
                    { new Guid("7f8320fd-b16d-4565-a596-4b1515eb94a2"), 25, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sachin Tomar", "Frontend Developer" },
                    { new Guid("c769e243-8dc9-48c9-8520-39220fff94f6"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Pawan Rajput", "UnityDeveloper" }
                });
        }
    }
}
