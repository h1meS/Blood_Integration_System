using Microsoft.EntityFrameworkCore.Migrations;

namespace BIS.DAL.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "BloodGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "BloodGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
