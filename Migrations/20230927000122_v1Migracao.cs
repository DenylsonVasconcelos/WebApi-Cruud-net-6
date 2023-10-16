using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICrud.Migrations
{
    /// <inheritdoc />
    public partial class v1Migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(55)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(55)", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
