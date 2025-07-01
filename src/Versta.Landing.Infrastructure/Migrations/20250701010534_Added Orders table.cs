using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Versta.Landing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_city = table.Column<string>(type: "text", nullable: false),
                    sender_address = table.Column<string>(type: "text", nullable: false),
                    receiver_city = table.Column<string>(type: "text", nullable: false),
                    receiver_address = table.Column<string>(type: "text", nullable: false),
                    package_weight_kg = table.Column<decimal>(type: "numeric", nullable: false),
                    package_pickup_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
