using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOOD_APP_JSB_2.Migrations
{
    /// <inheritdoc />
    public partial class updateuserclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Users");
        }
    }
}
