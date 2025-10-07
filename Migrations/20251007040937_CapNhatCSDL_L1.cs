using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLCHBanDienThoaiMoi.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatCSDL_L1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KhuyenMai",
                table: "SanPham");

            migrationBuilder.AddColumn<int>(
                name: "KhuyenMaiId",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_KhuyenMaiId",
                table: "SanPham",
                column: "KhuyenMaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_KhuyenMai_KhuyenMaiId",
                table: "SanPham",
                column: "KhuyenMaiId",
                principalTable: "KhuyenMai",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_KhuyenMai_KhuyenMaiId",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_KhuyenMaiId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "KhuyenMaiId",
                table: "SanPham");

            migrationBuilder.AddColumn<decimal>(
                name: "KhuyenMai",
                table: "SanPham",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
