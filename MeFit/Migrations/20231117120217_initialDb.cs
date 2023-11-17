using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeFit.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Difficulty = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkouts",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkouts", x => new { x.ExerciseId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkouts_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlan",
                columns: table => new
                {
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlan", x => new { x.PlanId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_WorkoutPlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPlan_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "Difficulty", "Equipment", "Image", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { new Guid("d3342565-af1d-4c64-b14c-432c5f2af5b9"), "Bicycle crunches are a great abdominal exercise that targets multiple muscle groups...", 2, "Exercise Mat", "https://example.com/bicyclecrunches.jpg", "Abdominals, Legs", "Bicycle Crunches" },
                    { new Guid("f21bf2b6-b150-4cee-be90-f59c81add994"), "Jumping jacks are a simple and effective cardiovascular exercise...", 1, "Jump Rope", "https://example.com/bicyclecrunches.jpg", "Legs, Arms, Cardio", "Jumping Jacks" }
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Description", "Difficulty", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("7d989a46-edef-451f-bc05-2cd76adebd66"), "An intermediate workout plan for advancing your fitness.", 2, "https://example.com/bicyclecrunches.jpg", "Intermediate Plan" },
                    { new Guid("d23dadd6-2283-4931-9620-b170f926a6c9"), "A beginner workout plan for getting started.", 1, "https://example.com/bicyclecrunches.jpg", "Beginner Plan" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Description", "Difficulty", "Equipment", "Image", "MuscleGroup", "Name", "Reps", "Sets" },
                values: new object[,]
                {
                    { new Guid("143798a3-f637-4764-a42f-f5b41088a2c2"), "High-Intensity Interval Training (HIIT)", 3, "Exercise Mat", "https://example.com/bicyclecrunches.jpg", "Cardio, Legs, Arms", "HIIT Workout", 12, 4 },
                    { new Guid("1f4c1c49-ec08-4137-b591-cf58bc86c160"), "Full Body Circuit", 2, "Jump Rope", "https://example.com/bicyclecrunches.jpg", "Legs, Arms, Core", "Full Body Circuit Workout", 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseWorkouts",
                columns: new[] { "ExerciseId", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("d3342565-af1d-4c64-b14c-432c5f2af5b9"), new Guid("143798a3-f637-4764-a42f-f5b41088a2c2") },
                    { new Guid("f21bf2b6-b150-4cee-be90-f59c81add994"), new Guid("1f4c1c49-ec08-4137-b591-cf58bc86c160") }
                });

            migrationBuilder.InsertData(
                table: "WorkoutPlan",
                columns: new[] { "PlanId", "WorkoutId" },
                values: new object[,]
                {
                    { new Guid("7d989a46-edef-451f-bc05-2cd76adebd66"), new Guid("143798a3-f637-4764-a42f-f5b41088a2c2") },
                    { new Guid("d23dadd6-2283-4931-9620-b170f926a6c9"), new Guid("1f4c1c49-ec08-4137-b591-cf58bc86c160") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_WorkoutId",
                table: "ExerciseWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlan_WorkoutId",
                table: "WorkoutPlan",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutPlan");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
