using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace heroes_company_api.Migrations
{
    public partial class AddDailyTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dailyTrainingsCounter",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "trainingSessionStarted",
                table: "Heroes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dailyTrainingsCounter",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "trainingSessionStarted",
                table: "Heroes");
        }
    }
}
