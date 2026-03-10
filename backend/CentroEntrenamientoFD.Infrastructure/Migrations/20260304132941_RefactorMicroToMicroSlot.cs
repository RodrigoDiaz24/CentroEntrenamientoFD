using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroEntrenamientoFD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMicroToMicroSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_RoutineDay_RoutineDayId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_MobilityExercise_ClientRoutines_ClientRoutineId",
                table: "MobilityExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineDay_ClientRoutines_ClientRoutineId",
                table: "RoutineDay");

            migrationBuilder.DropTable(
                name: "Micro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineDay",
                table: "RoutineDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MobilityExercise",
                table: "MobilityExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "RoutineDay",
                newName: "RoutineDays");

            migrationBuilder.RenameTable(
                name: "MobilityExercise",
                newName: "MobilityExercises");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_RoutineDay_ClientRoutineId",
                table: "RoutineDays",
                newName: "IX_RoutineDays_ClientRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_MobilityExercise_ClientRoutineId",
                table: "MobilityExercises",
                newName: "IX_MobilityExercises_ClientRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_RoutineDayId",
                table: "Exercises",
                newName: "IX_Exercises_RoutineDayId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineDays",
                table: "RoutineDays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobilityExercises",
                table: "MobilityExercises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MicroSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MicroSlots_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MicroSlots_ExerciseId",
                table: "MicroSlots",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises",
                column: "RoutineDayId",
                principalTable: "RoutineDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MobilityExercises_ClientRoutines_ClientRoutineId",
                table: "MobilityExercises",
                column: "ClientRoutineId",
                principalTable: "ClientRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineDays_ClientRoutines_ClientRoutineId",
                table: "RoutineDays",
                column: "ClientRoutineId",
                principalTable: "ClientRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_RoutineDays_RoutineDayId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MobilityExercises_ClientRoutines_ClientRoutineId",
                table: "MobilityExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineDays_ClientRoutines_ClientRoutineId",
                table: "RoutineDays");

            migrationBuilder.DropTable(
                name: "MicroSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineDays",
                table: "RoutineDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MobilityExercises",
                table: "MobilityExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "RoutineDays",
                newName: "RoutineDay");

            migrationBuilder.RenameTable(
                name: "MobilityExercises",
                newName: "MobilityExercise");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_RoutineDays_ClientRoutineId",
                table: "RoutineDay",
                newName: "IX_RoutineDay_ClientRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_MobilityExercises_ClientRoutineId",
                table: "MobilityExercise",
                newName: "IX_MobilityExercise_ClientRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_RoutineDayId",
                table: "Exercise",
                newName: "IX_Exercise_RoutineDayId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineDay",
                table: "RoutineDay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobilityExercise",
                table: "MobilityExercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Micro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Micro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Micro_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Micro_ExerciseId",
                table: "Micro",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_RoutineDay_RoutineDayId",
                table: "Exercise",
                column: "RoutineDayId",
                principalTable: "RoutineDay",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MobilityExercise_ClientRoutines_ClientRoutineId",
                table: "MobilityExercise",
                column: "ClientRoutineId",
                principalTable: "ClientRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineDay_ClientRoutines_ClientRoutineId",
                table: "RoutineDay",
                column: "ClientRoutineId",
                principalTable: "ClientRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
