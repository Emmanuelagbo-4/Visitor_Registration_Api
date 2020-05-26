using Microsoft.EntityFrameworkCore.Migrations;

namespace Visitors_Registration_System.Migrations
{
    public partial class ChangedPhoneNumberAndEmergencyContactToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Visitors",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContact",
                table: "Visitors",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Visitors",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "EmergencyContact",
                table: "Visitors",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }
    }
}
