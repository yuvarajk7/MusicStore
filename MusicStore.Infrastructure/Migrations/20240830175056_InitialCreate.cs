using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalSold = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Genre", "Name", "Rating", "ReleaseDate", "TotalSold" },
                values: new object[,]
                {
                    { 1, "Progressive Rock", "Dark Side of the Moon", 4.9000000000000004, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000000 },
                    { 2, "Pop", "Thriller", 4.7999999999999998, new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 66000000 },
                    { 3, "Rock", "Abbey Road", 4.7999999999999998, new DateTime(1969, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 31000000 },
                    { 4, "Hard Rock", "Back in Black", 4.7000000000000002, new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000000 },
                    { 5, "Rock", "Hotel California", 4.7000000000000002, new DateTime(1976, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 42000000 },
                    { 6, "Progressive Rock", "The Wall", 4.9000000000000004, new DateTime(1979, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 7, "Hard Rock", "Led Zeppelin IV", 4.7999999999999998, new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 37000000 },
                    { 8, "Rock", "Rumours", 4.9000000000000004, new DateTime(1977, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40000000 },
                    { 9, "Rock", "Sgt. Pepper's Lonely Hearts Club Band", 4.7000000000000002, new DateTime(1967, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 32000000 },
                    { 10, "Rock", "Born in the U.S.A.", 4.5999999999999996, new DateTime(1984, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 11, "Rock", "The Joshua Tree", 4.7999999999999998, new DateTime(1987, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000000 },
                    { 12, "Pop", "Bad", 4.7000000000000002, new DateTime(1987, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 35000000 },
                    { 13, "Pop", "Purple Rain", 4.7999999999999998, new DateTime(1984, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000000 },
                    { 14, "Hard Rock", "Appetite for Destruction", 4.7000000000000002, new DateTime(1987, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 15, "Pop", "Like a Virgin", 4.5, new DateTime(1984, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 21000000 },
                    { 16, "Grunge", "Nevermind", 4.9000000000000004, new DateTime(1991, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 17, "Rock", "Bat Out of Hell", 4.7999999999999998, new DateTime(1977, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 43000000 },
                    { 18, "Rock", "A Night at the Opera", 4.9000000000000004, new DateTime(1975, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000000 },
                    { 19, "Pop", "21", 4.7000000000000002, new DateTime(2011, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 31000000 },
                    { 20, "Rock", "Goodbye Yellow Brick Road", 4.7999999999999998, new DateTime(1973, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 21, "Pop", "Whitney Houston", 4.5999999999999996, new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000000 },
                    { 22, "Rock", "Brothers in Arms", 4.7000000000000002, new DateTime(1985, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000000 },
                    { 23, "Folk Rock", "Bridge Over Troubled Water", 4.7000000000000002, new DateTime(1970, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000000 },
                    { 24, "Rock", "Physical Graffiti", 4.7999999999999998, new DateTime(1975, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000000 },
                    { 25, "Pop", "Graceland", 4.7000000000000002, new DateTime(1986, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000000 }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "AlbumId", "Country", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "UK", "David", "Male", "Gilmour" },
                    { 2, 1, "UK", "Roger", "Male", "Waters" },
                    { 3, 2, "USA", "Michael", "Male", "Jackson" },
                    { 4, 2, "USA", "Quincy", "Male", "Jones" },
                    { 5, 3, "UK", "Paul", "Male", "McCartney" },
                    { 6, 3, "UK", "John", "Male", "Lennon" },
                    { 7, 3, "UK", "George", "Male", "Harrison" },
                    { 8, 3, "UK", "Ringo", "Male", "Starr" },
                    { 9, 4, "Australia", "Angus", "Male", "Young" },
                    { 10, 4, "UK", "Brian", "Male", "Johnson" },
                    { 11, 5, "USA", "Don", "Male", "Henley" },
                    { 12, 5, "USA", "Glenn", "Male", "Frey" },
                    { 13, 5, "USA", "Joe", "Male", "Walsh" },
                    { 14, 6, "UK", "Roger", "Male", "Waters" },
                    { 15, 6, "UK", "David", "Male", "Gilmour" },
                    { 16, 7, "UK", "Jimmy", "Male", "Page" },
                    { 17, 7, "UK", "Robert", "Male", "Plant" },
                    { 18, 7, "UK", "John", "Male", "Paul Jones" },
                    { 19, 8, "USA", "Stevie", "Female", "Nicks" },
                    { 20, 8, "USA", "Lindsey", "Male", "Buckingham" },
                    { 21, 8, "UK", "Christine", "Female", "McVie" },
                    { 22, 9, "UK", "Paul", "Male", "McCartney" },
                    { 23, 9, "UK", "John", "Male", "Lennon" },
                    { 24, 9, "UK", "George", "Male", "Harrison" },
                    { 25, 10, "USA", "Bruce", "Male", "Springsteen" },
                    { 26, 10, "USA", "Clarence", "Male", "Clemons" },
                    { 27, 11, "Ireland", "Bono", "Male", "" },
                    { 28, 11, "Ireland", "The Edge", "Male", "" },
                    { 29, 11, "Ireland", "Adam", "Male", "Clayton" },
                    { 30, 11, "Ireland", "Larry", "Male", "Mullen Jr." },
                    { 31, 12, "USA", "Michael", "Male", "Jackson" },
                    { 32, 13, "USA", "Prince", "Male", "" },
                    { 33, 14, "UK", "Slash", "Male", "" },
                    { 34, 14, "USA", "Axl", "Male", "Rose" },
                    { 35, 15, "USA", "Madonna", "Female", "" },
                    { 36, 16, "USA", "Kurt", "Male", "Cobain" },
                    { 37, 16, "USA", "Krist", "Male", "Novoselic" },
                    { 38, 17, "USA", "Meat", "Male", "Loaf" },
                    { 39, 18, "UK", "Brian", "Male", "May" },
                    { 40, 18, "UK", "Freddie", "Male", "Mercury" },
                    { 41, 19, "UK", "Adele", "Female", "Adkins" },
                    { 42, 19, "UK", "Paul", "Male", "Epworth" },
                    { 43, 20, "UK", "Elton", "Male", "John" },
                    { 44, 20, "UK", "Bernie", "Male", "Taupin" },
                    { 45, 21, "USA", "Whitney", "Female", "Houston" },
                    { 46, 21, "USA", "Narada", "Male", "Michael Walden" },
                    { 47, 22, "UK", "Mark", "Male", "Knopfler" },
                    { 48, 22, "UK", "John", "Male", "Illsley" },
                    { 49, 23, "USA", "Simon", "Male", "Garfunkel" },
                    { 50, 23, "USA", "Paul", "Male", "Simon" },
                    { 51, 23, "USA", "Art", "Male", "Garfunkel" },
                    { 52, 24, "UK", "Robert", "Male", "Plant" },
                    { 53, 24, "UK", "Jimmy", "Male", "Page" },
                    { 54, 24, "UK", "John", "Male", "Paul Jones" },
                    { 55, 25, "USA", "Simon", "Male", "Garfunkel" },
                    { 56, 25, "USA", "Paul", "Male", "Simon" },
                    { 57, 25, "South Africa", "Ray", "Male", "Phiri" },
                    { 58, 25, "South Africa", "Ladysmith", "Male", "Black Mambazo" },
                    { 59, 25, "USA", "Linda", "Female", "Ronstadt" },
                    { 60, 25, "South Africa", "Joseph", "Male", "Shabalala" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_AlbumId",
                table: "Artists",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
