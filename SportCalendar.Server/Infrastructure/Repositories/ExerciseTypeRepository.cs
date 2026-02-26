using Microsoft.EntityFrameworkCore;
using SportCalendar.Server.Application.Interfaces;
using SportCalendar.Server.Domain.Entities;
using SportCalendar.Server.Infrastructure.Data;

namespace SportCalendar.Server.Infrastructure.Repositories
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly AppDbContext _context;

        public ExerciseTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExerciseType>> GetAllAsync() => await _context.ExerciseTypes.ToListAsync();
    }
}
