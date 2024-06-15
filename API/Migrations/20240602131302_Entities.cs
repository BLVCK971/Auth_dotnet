using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Omless_OmlessId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Don_AspNetUsers_FanId",
                table: "Don");

            migrationBuilder.DropForeignKey(
                name: "FK_Don_Omless_OmlessId",
                table: "Don");

            migrationBuilder.DropForeignKey(
                name: "FK_Omless_Associations_AssociationId",
                table: "Omless");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Omless_OmlessId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Omless",
                table: "Omless");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Don",
                table: "Don");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "Omless",
                newName: "Omlesses");

            migrationBuilder.RenameTable(
                name: "Don",
                newName: "Dons");

            migrationBuilder.RenameIndex(
                name: "IX_Video_OmlessId",
                table: "Videos",
                newName: "IX_Videos_OmlessId");

            migrationBuilder.RenameIndex(
                name: "IX_Omless_AssociationId",
                table: "Omlesses",
                newName: "IX_Omlesses_AssociationId");

            migrationBuilder.RenameIndex(
                name: "IX_Don_OmlessId",
                table: "Dons",
                newName: "IX_Dons_OmlessId");

            migrationBuilder.RenameIndex(
                name: "IX_Don_FanId",
                table: "Dons",
                newName: "IX_Dons_FanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Omlesses",
                table: "Omlesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dons",
                table: "Dons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Omlesses_OmlessId",
                table: "AspNetUsers",
                column: "OmlessId",
                principalTable: "Omlesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dons_AspNetUsers_FanId",
                table: "Dons",
                column: "FanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dons_Omlesses_OmlessId",
                table: "Dons",
                column: "OmlessId",
                principalTable: "Omlesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Omlesses_Associations_AssociationId",
                table: "Omlesses",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Omlesses_OmlessId",
                table: "Videos",
                column: "OmlessId",
                principalTable: "Omlesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Omlesses_OmlessId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dons_AspNetUsers_FanId",
                table: "Dons");

            migrationBuilder.DropForeignKey(
                name: "FK_Dons_Omlesses_OmlessId",
                table: "Dons");

            migrationBuilder.DropForeignKey(
                name: "FK_Omlesses_Associations_AssociationId",
                table: "Omlesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Omlesses_OmlessId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Omlesses",
                table: "Omlesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dons",
                table: "Dons");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "Omlesses",
                newName: "Omless");

            migrationBuilder.RenameTable(
                name: "Dons",
                newName: "Don");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_OmlessId",
                table: "Video",
                newName: "IX_Video_OmlessId");

            migrationBuilder.RenameIndex(
                name: "IX_Omlesses_AssociationId",
                table: "Omless",
                newName: "IX_Omless_AssociationId");

            migrationBuilder.RenameIndex(
                name: "IX_Dons_OmlessId",
                table: "Don",
                newName: "IX_Don_OmlessId");

            migrationBuilder.RenameIndex(
                name: "IX_Dons_FanId",
                table: "Don",
                newName: "IX_Don_FanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Omless",
                table: "Omless",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Don",
                table: "Don",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Omless_OmlessId",
                table: "AspNetUsers",
                column: "OmlessId",
                principalTable: "Omless",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Don_AspNetUsers_FanId",
                table: "Don",
                column: "FanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Don_Omless_OmlessId",
                table: "Don",
                column: "OmlessId",
                principalTable: "Omless",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Omless_Associations_AssociationId",
                table: "Omless",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Omless_OmlessId",
                table: "Video",
                column: "OmlessId",
                principalTable: "Omless",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
