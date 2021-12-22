using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CEP.Infra.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Complemento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Localidade = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Ibge = table.Column<string>(type: "text", nullable: false),
                    Gia = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Ddd = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Siafi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEP");
        }
    }
}
