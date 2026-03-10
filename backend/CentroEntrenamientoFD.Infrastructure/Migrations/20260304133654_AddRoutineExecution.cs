using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroEntrenamientoFD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoutineExecution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutineExecutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientRoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExecutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseExecutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineExecutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExecutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseExecutions_RoutineExecutions_RoutineExecutionId",
                        column: x => x.RoutineExecutionId,
                        principalTable: "RoutineExecutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MicroExecutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotOrder = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    ExerciseExecutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroExecutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MicroExecutions_ExerciseExecutions_ExerciseExecutionId",
                        column: x => x.ExerciseExecutionId,
                        principalTable: "ExerciseExecutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExecutions_RoutineExecutionId",
                table: "ExerciseExecutions",
                column: "RoutineExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MicroExecutions_ExerciseExecutionId",
                table: "MicroExecutions",
                column: "ExerciseExecutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MicroExecutions");

            migrationBuilder.DropTable(
                name: "ExerciseExecutions");

            migrationBuilder.DropTable(
                name: "RoutineExecutions");
        }
    }
}
