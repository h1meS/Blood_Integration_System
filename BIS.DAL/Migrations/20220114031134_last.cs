using Microsoft.EntityFrameworkCore.Migrations;

namespace BIS.DAL.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorBloods_BloodGroups_DonorId",
                table: "DonorBloods");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBloods_BloodGroups_BloodGroupId",
                table: "DonorBloods",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorBloods_BloodGroups_BloodGroupId",
                table: "DonorBloods");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBloods_BloodGroups_DonorId",
                table: "DonorBloods",
                column: "DonorId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
