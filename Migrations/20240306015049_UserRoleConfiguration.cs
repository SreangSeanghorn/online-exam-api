using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2636901-9c81-4866-aaa4-508045007200");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c51ddc58-9c51-4ece-9def-dc1431f1e207");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dd5cde0-7a85-4b43-bce2-8969383154b0", null, "Admins", "ADMINS" },
                    { "98b10f5d-ae9e-4264-b313-57ec81c2b015", null, "Users", "USERS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Fullname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "7d50a24b-9f07-49ea-b7cd-8ee820cb5edc", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "s.seanghorn123@gmail.com", true, "Administator", false, null, "s.seanghorn123@gmail.com", "ADMIN", "AQAAAAIAAYagAAAAEB1Ofx1N00UpOE6wRIccPSSp8IIM3Kvl7FeNS1erekyq7cAl0vdiw5JxIGlwsGbisA==", null, false, "", false, "admin" },
                    { "2", 0, "fd4746db-16c8-4c74-a1be-afc89b330508", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ss@gmail.com", true, "ssh", false, null, "sseanghorn@gmail.ocm", "USER", "AQAAAAIAAYagAAAAELxV5mRpttGxRLUd57KOVreRWWe3uDcrMoeE8nOm5AQc4SQodCFQt7mtIjFuZIIdXg==", null, false, "", false, "ssh" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2dd5cde0-7a85-4b43-bce2-8969383154b0", "1" },
                    { "98b10f5d-ae9e-4264-b313-57ec81c2b015", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dd5cde0-7a85-4b43-bce2-8969383154b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98b10f5d-ae9e-4264-b313-57ec81c2b015");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2636901-9c81-4866-aaa4-508045007200", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c51ddc58-9c51-4ece-9def-dc1431f1e207", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2636901-9c81-4866-aaa4-508045007200", null, "Admin", "ADMIN" },
                    { "c51ddc58-9c51-4ece-9def-dc1431f1e207", null, "User", "USER" }
                });
        }
    }
}
