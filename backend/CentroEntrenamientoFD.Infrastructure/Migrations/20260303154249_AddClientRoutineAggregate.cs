using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroEntrenamientoFD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClientRoutineAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientRoutines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRoutines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobilityExercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientRoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilityExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilityExercise_ClientRoutines_ClientRoutineId",
                        column: x => x.ClientRoutineId,
                        principalTable: "ClientRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    ClientRoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineDay_ClientRoutines_ClientRoutineId",
                        column: x => x.ClientRoutineId,
                        principalTable: "ClientRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoutineDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_RoutineDay_RoutineDayId",
                        column: x => x.RoutineDayId,
                        principalTable: "RoutineDay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Micro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "IX_ClientRoutines_UserId",
                table: "ClientRoutines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_RoutineDayId",
                table: "Exercise",
                column: "RoutineDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Micro_ExerciseId",
                table: "Micro",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilityExercise_ClientRoutineId",
                table: "MobilityExercise",
                column: "ClientRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineDay_ClientRoutineId",
                table: "RoutineDay",
                column: "ClientRoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Micro");

            migrationBuilder.DropTable(
                name: "MobilityExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "RoutineDay");

            migrationBuilder.DropTable(
                name: "ClientRoutines");
        }
    }
}
