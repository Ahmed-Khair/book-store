using Microsoft.EntityFrameworkCore.Migrations;

namespace book_store.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authers",
                columns: table => new
                {
                    Id_auther = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authers", x => x.Id_auther);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Idbook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    imageurl = table.Column<string>(nullable: true),
                    AutherId_auther = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Idbook);
                    table.ForeignKey(
                        name: "FK_books_authers_AutherId_auther",
                        column: x => x.AutherId_auther,
                        principalTable: "authers",
                        principalColumn: "Id_auther",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AutherId_auther",
                table: "books",
                column: "AutherId_auther");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authers");
        }
    }
}
