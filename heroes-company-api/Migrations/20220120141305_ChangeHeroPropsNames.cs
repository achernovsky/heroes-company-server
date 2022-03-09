using Microsoft.EntityFrameworkCore.Migrations;

namespace heroes_company_api.Migrations
{
    public partial class ChangeHeroPropsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dailyTrainingsCounter",
                table: "Heroes",
                newName: "DailyTrainingsCounter");

            migrationBuilder.RenameColumn(
                name: "trainingSessionStarted",
                table: "Heroes",
                newName: "LastTrainingDate");

            migrationBuilder.RenameColumn(
                name: "StartedTraining",
                table: "Heroes",
                newName: "DateStartedTraining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyTrainingsCounter",
                table: "Heroes",
                newName: "dailyTrainingsCounter");

            migrationBuilder.RenameColumn(
                name: "LastTrainingDate",
                table: "Heroes",
                newName: "trainingSessionStarted");

            migrationBuilder.RenameColumn(
                name: "DateStartedTraining",
                table: "Heroes",
                newName: "StartedTraining");
        }
    }
}
