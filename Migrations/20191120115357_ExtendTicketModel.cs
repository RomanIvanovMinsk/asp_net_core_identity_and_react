using Microsoft.EntityFrameworkCore.Migrations;

namespace RomanCinema.Migrations
{
    public partial class ExtendTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoviePoster",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MoviePoster",
                table: "Tickets");
        }
    }
}
