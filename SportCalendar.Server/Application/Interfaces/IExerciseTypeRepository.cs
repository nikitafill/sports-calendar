using SportCalendar.Server.Domain.Entities;

namespace SportCalendar.Server.Application.Interfaces
{
    public interface IExerciseTypeRepository
    {
        Task<List<ExerciseType>> GetAllAsync();
    }
}
