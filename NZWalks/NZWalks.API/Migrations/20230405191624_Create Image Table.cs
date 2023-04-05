using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FileDescription = table.Column<string>(type: "longtext", nullable: true),
                    FileExtension = table.Column<string>(type: "longtext", nullable: false),
                    FileSizeinByte = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagesses", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagesses");

        }
    }
}
