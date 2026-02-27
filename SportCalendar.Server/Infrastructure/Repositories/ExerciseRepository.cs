using Microsoft.EntityFrameworkCore;
using SportCalendar.Server.Application.Interfaces;
using SportCalendar.Server.Domain.Entities;
using SportCalendar.Server.Infrastructure.Data;

namespace SportCalendar.Server.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _context;

        public ExerciseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Exercise>> GetByDate(DateOnly date)
        {
            return await _context.Exercises
                .Include(e => e.ExerciseType)
                .Where(x => x.ExerciseDate == date)
                .ToListAsync();
        }
        public async Task AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
        }
        public void Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
        }
        public void Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }
        public async Task<List<Exercise>> GetByMonth(int year, int month)
        {
            return await _context.Exercises
                .Include(e => e.ExerciseType)
                .Where(e =>
                    e.ExerciseDate.Year == year &&
                    e.ExerciseDate.Month == month)
                .ToListAsync();
        }
    }
}
