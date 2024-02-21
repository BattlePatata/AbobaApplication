using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbobaApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class intialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aboba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbobaQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbobbaAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aboba", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aboba");
        }
    }
}
