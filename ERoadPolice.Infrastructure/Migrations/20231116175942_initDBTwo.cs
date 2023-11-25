using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERoadPolice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDBTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Incidents",
                newName: "CarNumber");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Officers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Officers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FineAmount",
                table: "Incidents",
                type: "numeric",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseNumber",
                table: "Drivers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Drivers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "OnlyIdentificationNumber",
                table: "Drivers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "FineAmount",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "OnlyIdentificationNumber",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "CarNumber",
                table: "Incidents",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseNumber",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
