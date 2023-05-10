using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretApi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BannerListID",
                table: "Banners",
                newName: "BannersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BannersID",
                table: "Banners",
                newName: "BannerListID");
        }
    }
}
