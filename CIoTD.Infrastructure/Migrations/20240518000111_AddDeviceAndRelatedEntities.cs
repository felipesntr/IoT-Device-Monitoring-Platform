using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIoTD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceAndRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    CommandBytes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.CommandBytes);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CommandBytes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Parameters_Commands_CommandBytes",
                        column: x => x.CommandBytes,
                        principalTable: "Commands",
                        principalColumn: "CommandBytes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandDescriptions",
                columns: table => new
                {
                    Operation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CommandBytes = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Format = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DeviceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandDescriptions", x => x.Operation);
                    table.ForeignKey(
                        name: "FK_CommandDescriptions_Commands_CommandBytes",
                        column: x => x.CommandBytes,
                        principalTable: "Commands",
                        principalColumn: "CommandBytes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandDescriptions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandDescriptions_CommandBytes",
                table: "CommandDescriptions",
                column: "CommandBytes");

            migrationBuilder.CreateIndex(
                name: "IX_CommandDescriptions_DeviceId",
                table: "CommandDescriptions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_CommandBytes",
                table: "Parameters",
                column: "CommandBytes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandDescriptions");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
