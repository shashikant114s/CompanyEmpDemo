using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmpDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Gali no.251, Shilaj, Ahmedabad 380059", "IND", "Admin_Solutions Ltd" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Gali no.420, Thaltej, Ahmedabad 380058", "IND", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("37ce4894-d97f-475a-8285-0a1a5069e3d1"), 34, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Denish Makadiya", "Sr. UnityDeveloper" },
                    { new Guid("53060844-f781-4395-96dc-be17fe0c9cde"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Pawan Rajput", "UnityDeveloper" },
                    { new Guid("d3529e39-c5d2-4103-835d-e2a0e8e5f04b"), 28, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Rahul Tripathi", "Administrator" },
                    { new Guid("dbfb00a5-4970-4dc3-8e62-650da3edb2ae"), 25, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sachin Tomar", "Frontend Developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("37ce4894-d97f-475a-8285-0a1a5069e3d1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("53060844-f781-4395-96dc-be17fe0c9cde"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d3529e39-c5d2-4103-835d-e2a0e8e5f04b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("dbfb00a5-4970-4dc3-8e62-650da3edb2ae"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
