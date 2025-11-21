using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Main : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OTTPlatforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTTPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayementMethods",
                columns: table => new
                {
                    PayementMethodsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MethodName = table.Column<string>(type: "TEXT", nullable: false),
                    MethodDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementMethods", x => x.PayementMethodsId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlansDomainId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlanName = table.Column<string>(type: "TEXT", nullable: false),
                    PlanDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Validity = table.Column<int>(type: "INTEGER", nullable: false),
                    PlatformIds = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlansDomainId);
                });

            migrationBuilder.CreateTable(
                name: "SubUsers",
                columns: table => new
                {
                    SubUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubscribedPlansId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubUsers", x => x.SubUserId);
                });

            migrationBuilder.CreateTable(
                name: "Payements",
                columns: table => new
                {
                    PayementsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PayementMethodsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlansDomainId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    SubscribedPlansId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlansDomainId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlanName = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Validity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedPlans", x => x.SubscribedPlansId);
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
                name: "SubUsers");

            migrationBuilder.DropTable(
                name: "PayementMethods");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
