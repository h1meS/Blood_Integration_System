using Microsoft.EntityFrameworkCore.Migrations;

namespace BIS.DAL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodGroups",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Donors");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Donors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Donors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "BloodGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BloodGroups",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodGroups",
                table: "BloodGroups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                unique: true,
                filter: "[DonorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodGroups",
                table: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BloodGroups");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Donors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Donors",
                newName: "DonorId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "BloodGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodGroups",
                table: "BloodGroups",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "DonorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
