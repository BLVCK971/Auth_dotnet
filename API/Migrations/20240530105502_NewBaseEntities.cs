using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class NewBaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssociationId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OmlessId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Omless",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AssociationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omless", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Omless_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Don",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    OmlessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FanId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Don", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Don_AspNetUsers_FanId",
                        column: x => x.FanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Don_Omless_OmlessId",
                        column: x => x.OmlessId,
                        principalTable: "Omless",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    OmlessId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Omless_OmlessId",
                        column: x => x.OmlessId,
                        principalTable: "Omless",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AssociationId",
                table: "AspNetUsers",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OmlessId",
                table: "AspNetUsers",
                column: "OmlessId");

            migrationBuilder.CreateIndex(
                name: "IX_Don_FanId",
                table: "Don",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_Don_OmlessId",
                table: "Don",
                column: "OmlessId");

            migrationBuilder.CreateIndex(
                name: "IX_Omless_AssociationId",
                table: "Omless",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_OmlessId",
                table: "Video",
                column: "OmlessId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationId",
                table: "AspNetUsers",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Omless_OmlessId",
                table: "AspNetUsers",
                column: "OmlessId",
                principalTable: "Omless",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Omless_OmlessId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Don");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Omless");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AssociationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OmlessId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OmlessId",
                table: "AspNetUsers");
        }
    }
}
