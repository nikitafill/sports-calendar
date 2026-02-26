using System.ComponentModel.DataAnnotations;

namespace SportCalendar.Server.Domain.Entities
{
    public class ExerciseType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        // km / min / reps
        public string ProgressUnit { get; set; } = null!;

        // Navigation property
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
