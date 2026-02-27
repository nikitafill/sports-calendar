using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportCalendar.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExerciseTypeentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ExerciseTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ExerciseTypes",
                type: "text",
                nullable: true);
        }
    }
}
