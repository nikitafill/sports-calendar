using SportCalendar.Server.Application.Interfaces;
using SportCalendar.Server.Domain.Entities;

namespace SportCalendar.Server.Application.Services
{
    public class ExerciseTypeService
    {
        private readonly IExerciseTypeRepository _repository;
        public ExerciseTypeService(IExerciseTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ExerciseType>> GetAllAsync()
        => await _repository.GetAllAsync();
    }
}
