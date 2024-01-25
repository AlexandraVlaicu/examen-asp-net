using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examen.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ev",
                columns: table => new
                {
                    idev = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    durata = table.Column<int>(type: "int", nullable: false),
                    nrparticipanti = table.Column<int>(type: "int", nullable: false),
                    nume = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ev", x => x.idev);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "P",
                columns: table => new
                {
                    idpart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nume = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P", x => x.idpart);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EvenimenteParticipanti",
                columns: table => new
                {
                    Evidev = table.Column<int>(type: "int", nullable: false),
                    Pidpart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenimenteParticipanti", x => new { x.Evidev, x.Pidpart });
                    table.ForeignKey(
                        name: "FK_EvenimenteParticipanti_Ev_Evidev",
                        column: x => x.Evidev,
                        principalTable: "Ev",
                        principalColumn: "idev",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenimenteParticipanti_P_Pidpart",
                        column: x => x.Pidpart,
                        principalTable: "P",
                        principalColumn: "idpart",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EVo",
                columns: table => new
                {
                    idevo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Evenimenteidev = table.Column<int>(type: "int", nullable: false),
                    Participantiidpart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVo", x => x.idevo);
                    table.ForeignKey(
                        name: "FK_EVo_Ev_Evenimenteidev",
                        column: x => x.Evenimenteidev,
                        principalTable: "Ev",
                        principalColumn: "idev",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EVo_P_Participantiidpart",
                        column: x => x.Participantiidpart,
                        principalTable: "P",
                        principalColumn: "idpart",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EvenimenteParticipanti_Pidpart",
                table: "EvenimenteParticipanti",
                column: "Pidpart");

            migrationBuilder.CreateIndex(
                name: "IX_EVo_Evenimenteidev",
                table: "EVo",
                column: "Evenimenteidev");

            migrationBuilder.CreateIndex(
                name: "IX_EVo_Participantiidpart",
                table: "EVo",
                column: "Participantiidpart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvenimenteParticipanti");

            migrationBuilder.DropTable(
                name: "EVo");

            migrationBuilder.DropTable(
                name: "Ev");

            migrationBuilder.DropTable(
                name: "P");
        }
    }
}
