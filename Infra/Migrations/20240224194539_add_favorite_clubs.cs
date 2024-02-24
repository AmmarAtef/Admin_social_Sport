using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class add_favorite_clubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("2790a93d-64b0-4ca9-b690-64fc15355dbd"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("f2de76a4-edaa-4838-92cb-6dd5baf7bda1"));

            migrationBuilder.CreateTable(
                name: "FavoriteClubs",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteClubs", x => new { x.UserId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_FavoriteClubs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteClubs_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("8283b64b-c670-4558-9ca9-6e8be04516ff"), new DateTime(2024, 2, 24, 13, 45, 39, 91, DateTimeKind.Local).AddTicks(7900), "System", null, null, false, "Basketball", null, null });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("fb564aa2-5ac2-45e0-8385-ae92ab5a9a74"), new DateTime(2024, 2, 24, 13, 45, 39, 91, DateTimeKind.Local).AddTicks(7829), "System", null, null, false, "Football", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteClubs_ClubId",
                table: "FavoriteClubs",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteClubs");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("8283b64b-c670-4558-9ca9-6e8be04516ff"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("fb564aa2-5ac2-45e0-8385-ae92ab5a9a74"));

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("2790a93d-64b0-4ca9-b690-64fc15355dbd"), new DateTime(2024, 2, 17, 17, 54, 22, 364, DateTimeKind.Local).AddTicks(3323), "System", null, null, false, "Football", null, null });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("f2de76a4-edaa-4838-92cb-6dd5baf7bda1"), new DateTime(2024, 2, 17, 17, 54, 22, 364, DateTimeKind.Local).AddTicks(3386), "System", null, null, false, "Basketball", null, null });
        }
    }
}
