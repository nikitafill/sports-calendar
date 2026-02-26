using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportCalendar.Server.Domain.Enum;

namespace SportCalendar.Server.Domain.Entities
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        public int ExerciseTypeId { get; set; }

        [ForeignKey(nameof(ExerciseTypeId))]
        public ExerciseType ExerciseType { get; set; } = null!;

        [Required]
        public DateOnly ExerciseDate { get; set; }

        [Required]
        public decimal ProgressValue { get; set; }

        public ExerciseStatus Status { get; set; } = ExerciseStatus.Planned;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
