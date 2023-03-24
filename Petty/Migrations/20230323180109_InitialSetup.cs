using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petty.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksList",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_Amount = table.Column<int>(type: "int", nullable: false),
                    Book_Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksList", x => x.Book_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksList");
        }
    }
}
