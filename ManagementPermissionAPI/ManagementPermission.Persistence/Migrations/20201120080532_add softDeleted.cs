using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementPermission.Persistence.Migrations
{
    public partial class addsoftDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TypeOfPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeOfPermission");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Permission");
        }
    }
}
