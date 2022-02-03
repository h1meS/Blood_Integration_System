using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BIS.DAL.Migrations
{
    public partial class fourth : Migration
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
                name: "ContactNumber",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Diseases",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Blood",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BloodGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BloodGroups");

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "BloodGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodGroups_Donors_DonorId",
                table: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_DonorId",
                table: "BloodGroups");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "Donors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Diseases",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Donors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Donors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "BloodGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Blood",
                table: "BloodGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BloodGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BloodGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
