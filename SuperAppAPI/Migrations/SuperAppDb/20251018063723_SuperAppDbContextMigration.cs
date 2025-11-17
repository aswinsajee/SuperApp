using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAppAPI.Migrations.SuperAppDb
{
    /// <inheritdoc />
    public partial class SuperAppDbContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OTTPlatforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTTPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayementMethods",
                columns: table => new
                {
                    PayementMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementMethods", x => x.PayementMethodsId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlansDomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Validity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlansDomainId);
                });

            migrationBuilder.CreateTable(
                name: "Payements",
                columns: table => new
                {
                    PayementsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayementMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlansDomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payements", x => x.PayementsID);
                    table.ForeignKey(
                        name: "FK_Payements_PayementMethods_PayementMethodsId",
                        column: x => x.PayementMethodsId,
                        principalTable: "PayementMethods",
                        principalColumn: "PayementMethodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payements_Plans_PlansDomainId",
                        column: x => x.PlansDomainId,
                        principalTable: "Plans",
                        principalColumn: "PlansDomainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscribedPlansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlansDomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscribedPlans_Plans_PlansDomainId",
                        column: x => x.PlansDomainId,
                        principalTable: "Plans",
                        principalColumn: "PlansDomainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payements_PayementMethodsId",
                table: "Payements",
                column: "PayementMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payements_PlansDomainId",
                table: "Payements",
                column: "PlansDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedPlans_PlansDomainId",
                table: "SubscribedPlans",
                column: "PlansDomainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTTPlatforms");

            migrationBuilder.DropTable(
                name: "Payements");

            migrationBuilder.DropTable(
                name: "SubscribedPlans");

            migrationBuilder.DropTable(
                name: "PayementMethods");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
