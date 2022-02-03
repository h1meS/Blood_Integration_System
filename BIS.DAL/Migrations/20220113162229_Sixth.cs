using Microsoft.EntityFrameworkCore.Migrations;

namespace BIS.DAL.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups");

            migrationBuilder.CreateTable(
                name: "DonorBloods",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    BloodGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorBloods", x => new { x.BloodGroupId, x.DonorId });
                    table.ForeignKey(
                        name: "FK_DonorBloods_BloodGroups_DonorId",
                        column: x => x.DonorId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorBloods_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorBloods_DonorId",
                table: "DonorBloods",
                column: "DonorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorBloods");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                unique: true);
        }
    }
}
