using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UF = table.Column<string>(type: "char(2)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IbgeCode = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ceps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublicPlace = table.Column<string>(type: "varchar(60)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceps_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedAt", "Name", "UF", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("26bf4fac-6b74-460e-bc35-369fb85fe377"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(7865), "Acre", "AC", null },
                    { new Guid("5daf0fe5-8f3c-4154-9a02-4461b24ef4b4"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9963), "São Paulo", "SP", null },
                    { new Guid("f24fe1b9-e603-40b5-b2f9-8093573e7113"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9961), "Santa Catarina", "SC", null },
                    { new Guid("fb452cc9-e353-40a8-a665-d7068b850368"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9958), "Rio Grande do Sul", "RS", null },
                    { new Guid("568ae91a-b32c-4e7c-b73f-5ced9a45f57d"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9956), "Rio Grande do Norte", "RN", null },
                    { new Guid("1c5d6cc4-238f-4ec4-92a9-7a8527ed748c"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9948), "Rio de Janeiro", "RJ", null },
                    { new Guid("37976964-35a8-402a-99f8-722ec20f02e4"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9946), "Rondônia", "RO", null },
                    { new Guid("76cff268-7cc8-4880-a68d-30b62a3d2078"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9943), "Roraima", "RR", null },
                    { new Guid("24887789-2e1f-4bbf-a7a0-7a89b4c3a375"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9941), "Piauí", "PI", null },
                    { new Guid("f28c3aef-c9fb-4ebd-893b-73465076bf6c"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9938), "Pernambuco", "PE", null },
                    { new Guid("0d40fab2-a84d-4c7b-af0d-277f6126231f"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9936), "Paraná", "PR", null },
                    { new Guid("cb940838-bd25-4fd9-9725-cc8dbee1b4d3"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9933), "Paraíba", "PB", null },
                    { new Guid("0d71963e-293a-4404-be05-b6885762741c"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9965), "Sergipe", "SE", null },
                    { new Guid("6bc32d62-69bd-4bb8-8ed1-e4e501cd286b"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9930), "Pará", "PA", null },
                    { new Guid("62fbeef7-6abb-40a4-824f-d804c2f38af4"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9921), "Mato Grosso do Sul", "MS", null },
                    { new Guid("a87c1f9e-91d6-423f-97ea-4bcf8b9c2081"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9919), "Mato Grosso", "MT", null },
                    { new Guid("f04c8df2-3b2b-4e2c-8f05-96790e90754e"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9916), "Maranhão", "MA", null },
                    { new Guid("365ec8d9-b410-41b4-9469-a327769c0306"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9914), "Goiás", "GO", null },
                    { new Guid("29197f73-1055-47e9-b046-7e0d77fcb067"), null, "Espírito Santo", "ES", null },
                    { new Guid("2b8e410c-794d-4dd7-8544-942d5bfd98aa"), null, "Distrito Federal", "DF", null },
                    { new Guid("2ee0a586-66d5-42e4-b476-b0deb61bc551"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9903), "Ceará", "CE", null },
                    { new Guid("292f77a4-29dc-4b17-8c5f-ced63b97f7af"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9878), "Bahia", "BA", null },
                    { new Guid("150fd692-63ad-4a2c-bfdd-43a7afdb2ebf"), null, "Amazonas", "AM", null },
                    { new Guid("9b7d755c-4ddc-4a19-920f-9281a669f6b2"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9873), "Amapá", "AP", null },
                    { new Guid("bb34110c-1bb0-4d57-8fa6-a47791f8d53d"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9866), "Alagoas", "AL", null },
                    { new Guid("350d3fa9-87f5-4235-9977-d93b55255817"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9923), "Minas Gerais", "MG", null },
                    { new Guid("d8ab2dc4-51e0-4e2a-9f5a-98ef2056d207"), new DateTime(2021, 12, 23, 18, 18, 26, 127, DateTimeKind.Utc).AddTicks(9970), "Tocantins", "TO", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ceps_CEP",
                table: "Ceps",
                column: "CEP");

            migrationBuilder.CreateIndex(
                name: "IX_Ceps_CityId",
                table: "Ceps",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IbgeCode",
                table: "Cities",
                column: "IbgeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_UF",
                table: "States",
                column: "UF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ceps");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
