﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 5, 15, 10, 23, 50, 766, DateTimeKind.Local).AddTicks(9025), new DateTime(2025, 5, 15, 10, 23, 50, 766, DateTimeKind.Local).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 5, 15, 10, 23, 50, 766, DateTimeKind.Local).AddTicks(9035), new DateTime(2025, 5, 15, 10, 23, 50, 766, DateTimeKind.Local).AddTicks(9033) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 5, 1, 12, 5, 42, 363, DateTimeKind.Local).AddTicks(2690), new DateTime(2025, 5, 1, 12, 5, 42, 363, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2025, 5, 1, 12, 5, 42, 363, DateTimeKind.Local).AddTicks(2692), new DateTime(2025, 5, 1, 12, 5, 42, 363, DateTimeKind.Local).AddTicks(2692) });
        }
    }
}
