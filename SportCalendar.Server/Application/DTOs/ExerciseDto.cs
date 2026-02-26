namespace SportCalendar.Server.Application.DTOs
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public DateOnly ExerciseDate { get; set; }
        public decimal ProgressValue { get; set; }
        public int Status { get; set; }

        public string ExerciseTypeName { get; set; } = "";
        public string ProgressUnit { get; set; } = "";
    }
}
