namespace SportCalendar.Server.Application.DTOs
{
    public class CalendarDayDto
    {
        public DateOnly Date { get; set; }
        public List<CalendarExerciseDto> Exercises { get; set; }
    }
}
