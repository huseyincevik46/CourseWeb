using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWeb.Migrations
{
    /// <inheritdoc />
    public partial class ModelChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(19)",
                maxLength: 19,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(19)",
                maxLength: 19,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(19)",
                maxLength: 19,
                nullable: false,
                defaultValue: "");
        }
    }
}
