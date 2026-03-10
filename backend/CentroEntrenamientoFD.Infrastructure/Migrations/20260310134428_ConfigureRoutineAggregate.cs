using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroEntrenamientoFD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureRoutineAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises",
                column: "RoutineDayId",
                principalTable: "RoutineDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises",
                column: "RoutineDayId",
                principalTable: "RoutineDays",
                principalColumn: "Id");
        }
    }
}
