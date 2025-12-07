using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
