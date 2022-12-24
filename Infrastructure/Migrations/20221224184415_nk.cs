using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "90b972b3-8635-49a0-8f7c-a2e1d5e416c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03c02546-3b6e-4e83-99ea-45edbebfe7e3", "AQAAAAEAACcQAAAAEHEuGnS5BC+ylJpzaRCG6yUAoCmllbYG4vO2cT2vH2VOFbyFMqLJ4eIJvAs+HK9tIw==", "3d18a923-c00c-4b43-a657-77b0e825e8b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dde1e9a6-a04c-4a92-887b-073bac17f667");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a579185-bc7f-4e40-af11-aa5a77cdfff3", "AQAAAAEAACcQAAAAEHveX8LLLQExzoASF6aViUAMt3xnPA3kRS59dMKssh57lWatuuuu6PNOxR/u9jGb5g==", "6513e2ab-0fe1-4ea9-b2d9-a363d03f0127" });
        }
    }
}
