using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picket_Id",
                table: "PlatformsPickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Platform_Id",
                table: "PlatformsPickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformsPickets",
                table: "PlatformsPickets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlatformsPickets",
                newName: "PlatformsId");

            migrationBuilder.AddColumn<int>(
                name: "PicketsId",
                table: "PlatformsPickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformsPickets",
                table: "PlatformsPickets",
                columns: new[] { "PicketsId", "PlatformsId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsPickets_PlatformsId",
                table: "PlatformsPickets",
                column: "PlatformsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformsPickets_Pickets_PicketsId",
                table: "PlatformsPickets",
                column: "PicketsId",
                principalTable: "Pickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformsPickets_Platforms_PlatformsId",
                table: "PlatformsPickets",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformsPickets_Pickets_PicketsId",
                table: "PlatformsPickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformsPickets_Platforms_PlatformsId",
                table: "PlatformsPickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformsPickets",
                table: "PlatformsPickets");

            migrationBuilder.DropIndex(
                name: "IX_PlatformsPickets_PlatformsId",
                table: "PlatformsPickets");

            migrationBuilder.DropColumn(
                name: "PicketsId",
                table: "PlatformsPickets");

            migrationBuilder.RenameColumn(
                name: "PlatformsId",
                table: "PlatformsPickets",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformsPickets",
                table: "PlatformsPickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picket_Id",
                table: "PlatformsPickets",
                column: "Id",
                principalTable: "Pickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platform_Id",
                table: "PlatformsPickets",
                column: "Id",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
