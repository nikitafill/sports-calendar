using SportCalendar.Server.Domain.Entities;

namespace SportCalendar.Server.Application.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetByDate(DateOnly date);
        Task AddAsync(Exercise exercise);
        void Update(Exercise exercise);
        void Delete(Exercise exercise);
        Task SaveChangesAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task<List<Exercise>> GetByMonth(int year, int month);
    }
}
