using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PI4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Onderwerpen",
                columns: table => new
                {
                    OnderwerpId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderwerpen", x => x.OnderwerpId);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Titel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "OnderwerpVideo",
                columns: table => new
                {
                    OnderwerpenOnderwerpId = table.Column<int>(type: "INTEGER", nullable: false),
                    VideosVideoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderwerpVideo", x => new { x.OnderwerpenOnderwerpId, x.VideosVideoId });
                    table.ForeignKey(
                        name: "FK_OnderwerpVideo_Onderwerpen_OnderwerpenOnderwerpId",
                        column: x => x.OnderwerpenOnderwerpId,
                        principalTable: "Onderwerpen",
                        principalColumn: "OnderwerpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderwerpVideo_Videos_VideosVideoId",
                        column: x => x.VideosVideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnderwerpVideo_VideosVideoId",
                table: "OnderwerpVideo",
                column: "VideosVideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnderwerpVideo");

            migrationBuilder.DropTable(
                name: "Onderwerpen");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
