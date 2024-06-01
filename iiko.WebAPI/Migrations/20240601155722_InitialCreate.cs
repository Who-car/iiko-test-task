using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    SystemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "SystemId", "Username" },
                values: new object[,]
                {
                    { 1L, new Guid("db66578d-dc8a-4d0f-c6ca-75f2c6c9dbf7"), "Shane_Sanford" },
                    { 2L, new Guid("29b7df70-4906-c060-0578-5ea69537a406"), "Paula_Schaden59" },
                    { 3L, new Guid("af1c453d-f0f5-e9a8-f770-c59d63ba921b"), "Florencio_Fahey98" },
                    { 4L, new Guid("407d3410-0d2d-3975-cacd-fa436aabc74c"), "Furman0" },
                    { 5L, new Guid("264d10f5-b6a5-7d81-25f7-fad757bb1599"), "Robert_Collins91" },
                    { 6L, new Guid("104b6838-3a35-576d-de6a-c9b6cc753783"), "Easton.Robel90" },
                    { 7L, new Guid("70219038-81b2-4afa-5beb-a5f9a879902f"), "Jewell.Lynch13" },
                    { 8L, new Guid("4a641665-61ff-abe4-985b-b092d3a29bf8"), "Felicity4" },
                    { 9L, new Guid("33c6a3b5-2996-8374-3519-78e334bcb891"), "Nicole89" },
                    { 10L, new Guid("582a7ae6-d7d3-0940-c32d-de0df1992c38"), "Catherine.Cremin57" },
                    { 11L, new Guid("16e32d8c-6121-a1dc-1450-ecf4e876d399"), "Stacy93" },
                    { 12L, new Guid("15bc4826-6f49-ad93-59a6-35a4dcc627fb"), "Robyn.Reilly" },
                    { 13L, new Guid("c21e3ed7-dea7-4ec0-35b1-1533cffdfbe6"), "Shawn_Robel" },
                    { 14L, new Guid("bc2bd8da-86c6-0d12-5a6b-7b8942b3edb3"), "Virgie.Ortiz99" },
                    { 15L, new Guid("275aaa6a-861a-163c-bb44-3cdcd3074f12"), "Makenna_Shanahan" },
                    { 16L, new Guid("02d4bec6-12af-beb6-cd3b-a829d369988a"), "Polly88" },
                    { 17L, new Guid("b3bb7725-dd41-d82f-7cc0-15fac2a34c4a"), "Clovis91" },
                    { 18L, new Guid("fdbfb29b-9145-5a89-1db1-935cd974f14b"), "Ladarius_Dach54" },
                    { 19L, new Guid("91229917-4e08-fa26-04bf-4fa26d727942"), "Leif55" },
                    { 20L, new Guid("4d29ba57-a365-15f5-11a1-1016f47a0656"), "Jarret.Douglas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
