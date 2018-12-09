using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Repositories.Migrations
{
    public partial class Associados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KinShip",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinShip", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Associated",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    maritalstatusid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    dateJoin = table.Column<string>(nullable: true),
                    adress = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    birthDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associated", x => x.id);
                    table.ForeignKey(
                        name: "FK_Associated_MaritalStatus_maritalstatusid",
                        column: x => x.maritalstatusid,
                        principalTable: "MaritalStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    associatedid = table.Column<int>(nullable: false),
                    kinshipid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    birthDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dependent_Associated_associatedid",
                        column: x => x.associatedid,
                        principalTable: "Associated",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependent_KinShip_kinshipid",
                        column: x => x.kinshipid,
                        principalTable: "KinShip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associated_maritalstatusid",
                table: "Associated",
                column: "maritalstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_associatedid",
                table: "Dependent",
                column: "associatedid");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_kinshipid",
                table: "Dependent",
                column: "kinshipid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Associated");

            migrationBuilder.DropTable(
                name: "KinShip");

            migrationBuilder.DropTable(
                name: "MaritalStatus");
        }
    }
}
