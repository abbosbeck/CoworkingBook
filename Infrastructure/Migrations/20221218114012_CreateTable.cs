using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8f6b5f7-c130-46e4-bd91-37a876878f51", "AQAAAAEAACcQAAAAEMFgkL/T3P3LfcWV6kzG9zbyLedFX5kyVC+sm6Oxsg2vUQiv0VQYhAqqf5WraPJrtg==", "eea353bb-1b42-4f98-81a3-26c37a0eb49f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f26af89-c534-4f5c-8d20-e2ab971075b0", "AQAAAAEAACcQAAAAEN989E4bcO+q/BlSbftkn0qtW9dvH4ByG+ASWyVg25z65uL6m5nOMcH/QAvX3CIbhw==", "c58b113e-91f6-439e-83d0-761cc17c8b5e" });
        }
    }
}
