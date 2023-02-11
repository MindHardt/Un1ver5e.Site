using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Un1ver5e.Site.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCharacterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterDraft");

            migrationBuilder.CreateTable(
                name: "CharacterDraftSnapshot",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDraftSnapshot", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterDraftSnapshot");

            migrationBuilder.CreateTable(
                name: "CharacterDraft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDraft", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterDraft_Name",
                table: "CharacterDraft",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
