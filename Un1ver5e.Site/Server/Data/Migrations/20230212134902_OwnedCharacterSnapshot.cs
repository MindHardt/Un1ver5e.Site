using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Un1ver5e.Site.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class OwnedCharacterSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterDraftSnapshot");

            migrationBuilder.CreateTable(
                name: "OwnedCharacterDraftSnapshot",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCharacterDraftSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedCharacterDraftSnapshot_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCharacterDraftSnapshot_OwnerId",
                table: "OwnedCharacterDraftSnapshot",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedCharacterDraftSnapshot");

            migrationBuilder.CreateTable(
                name: "CharacterDraftSnapshot",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDraftSnapshot", x => x.Id);
                });
        }
    }
}
