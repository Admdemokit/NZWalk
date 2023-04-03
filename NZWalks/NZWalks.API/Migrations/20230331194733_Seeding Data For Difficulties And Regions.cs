using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1a58e359-a485-4676-83a2-86621e63014b"), "Easy" },
                    { new Guid("805055d0-3d4f-4038-be19-a5f4fba44457"), "Hard" },
                    { new Guid("9cd98fdd-98a2-4ebd-be3b-c81efdbef18c"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("0ccefb3b-08e0-4f3e-989a-5943bf8333c8"), "JPN", "Japan", "https://images.pexels.com/photos/1440476/pexels-photo-1440476.jpeg" },
                    { new Guid("51aaf94f-b26d-46d0-8cc5-ffbfd9c742bd"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("8a893678-c59a-4a54-9e8f-b4261dba5625"), "WJAV", "West Java", "https://images.pexels.com/photos/2916337/pexels-photo-2916337.jpeg" },
                    { new Guid("8c2e406e-1cf4-4a63-8366-8324293c63ab"), "BOP", "Bay Of Plenty", null },
                    { new Guid("d96cad25-1fa5-4eed-888b-125a3b06f09d"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f78b61d2-4931-4628-9de8-ea2c26e9f9bc"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1a58e359-a485-4676-83a2-86621e63014b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("805055d0-3d4f-4038-be19-a5f4fba44457"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9cd98fdd-98a2-4ebd-be3b-c81efdbef18c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0ccefb3b-08e0-4f3e-989a-5943bf8333c8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51aaf94f-b26d-46d0-8cc5-ffbfd9c742bd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8a893678-c59a-4a54-9e8f-b4261dba5625"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8c2e406e-1cf4-4a63-8366-8324293c63ab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d96cad25-1fa5-4eed-888b-125a3b06f09d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f78b61d2-4931-4628-9de8-ea2c26e9f9bc"));
        }
    }
}
