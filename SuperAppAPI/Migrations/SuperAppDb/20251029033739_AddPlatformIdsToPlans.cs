using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAppAPI.Migrations.SuperAppDb
{
    /// <inheritdoc />
    public partial class AddPlatformIdsToPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscribedPlans",
                table: "SubscribedPlans");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubscribedPlans",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SubscribedPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PlanName",
                table: "SubscribedPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "SubscribedPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Validity",
                table: "SubscribedPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlatformIds",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Payements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Payements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscribedPlans",
                table: "SubscribedPlans",
                column: "SubscribedPlansId");

            migrationBuilder.CreateTable(
                name: "SubUsers",
                columns: table => new
                {
                    SubUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscribedPlansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubUsers", x => x.SubUserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscribedPlans",
                table: "SubscribedPlans");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SubscribedPlans");

            migrationBuilder.DropColumn(
                name: "PlanName",
                table: "SubscribedPlans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "SubscribedPlans");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "SubscribedPlans");

            migrationBuilder.DropColumn(
                name: "PlatformIds",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payements");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SubscribedPlans",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Payements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscribedPlans",
                table: "SubscribedPlans",
                column: "Id");
        }
    }
}
