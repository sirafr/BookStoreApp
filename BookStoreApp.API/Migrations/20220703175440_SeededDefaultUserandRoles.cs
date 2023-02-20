using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a44931f-cc87-4e09-96b9-bf5a5f48ca37", "adb3b0c4-23c2-4da2-8c1c-d455b4cc6968", "Administrator", "ADMINISTRATOR" },
                    { "c3fc13df-51c7-49a7-9797-30f04d4752a1", "ec91390f-2d4f-44fe-9587-869bf3b5bb9c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29db6215-88b5-4a75-8f92-88b7c3844abb", 0, "623ee08d-55b9-43bf-bfc7-b5a560bc60bb", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAENNJA9I31LClAJw11af6P5OjoIksBeMZpWc7x2jyjdSaeLAFZtOkEolqWsW9ux7ivA==", null, false, "aeb7fd19-cb2e-4dcf-92c2-3a1a8f9a4ae3", false, "admin@bookstore.com" },
                    { "c9eb3649-94ab-4a0d-a21b-cc499b618032", 0, "10e718a5-f323-4c44-9496-d00aaea8b160", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEJUk4x2BsnqmqDC2u7jV8RQPmzpZbhQl5nfLiRbPXXm0+s+lMoGSZioL6reIAIQ7Ew==", null, false, "97e781db-695d-41e7-abe0-9883531c2e2c", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9a44931f-cc87-4e09-96b9-bf5a5f48ca37", "29db6215-88b5-4a75-8f92-88b7c3844abb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3fc13df-51c7-49a7-9797-30f04d4752a1", "c9eb3649-94ab-4a0d-a21b-cc499b618032" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a44931f-cc87-4e09-96b9-bf5a5f48ca37", "29db6215-88b5-4a75-8f92-88b7c3844abb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3fc13df-51c7-49a7-9797-30f04d4752a1", "c9eb3649-94ab-4a0d-a21b-cc499b618032" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a44931f-cc87-4e09-96b9-bf5a5f48ca37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3fc13df-51c7-49a7-9797-30f04d4752a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29db6215-88b5-4a75-8f92-88b7c3844abb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9eb3649-94ab-4a0d-a21b-cc499b618032");
        }
    }
}
