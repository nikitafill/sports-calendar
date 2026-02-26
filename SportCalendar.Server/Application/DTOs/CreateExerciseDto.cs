namespace SportCalendar.Server.Application.DTOs
{
    public class CreateExerciseDto
    {
        public int ExerciseTypeId { get; set; }
        public DateOnly ExerciseDate { get; set; }
        public decimal ProgressValue { get; set; }
    }
}
