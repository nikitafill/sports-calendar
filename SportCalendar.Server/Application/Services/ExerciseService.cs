using SportCalendar.Server.Application.DTOs;
using SportCalendar.Server.Application.Interfaces;
using SportCalendar.Server.Domain.Entities;
using SportCalendar.Server.Domain.Enum;

namespace SportCalendar.Server.Application.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _repository;

        public ExerciseService(IExerciseRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ExerciseDto>> GetExercises(DateOnly date)
        {
            var exercises = await _repository.GetByDate(date);

            return exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                ExerciseDate = e.ExerciseDate,
                ProgressValue = e.ProgressValue,
                Status = (int)e.Status,
                ExerciseTypeName = e.ExerciseType.Name,
                ProgressUnit = e.ExerciseType.ProgressUnit
            }).ToList();
        }
        public async Task AddAsync(CreateExerciseDto dto)
        {
            var exercise = new Exercise
            {
                ExerciseTypeId = dto.ExerciseTypeId,
                ExerciseDate = dto.ExerciseDate,
                ProgressValue = dto.ProgressValue
            };

            await _repository.AddAsync(exercise);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateStatus(int id, int status)
        {
            var exercise = await _repository.GetByIdAsync(id);

            if (exercise == null)
                throw new Exception("Not found");

            exercise.Status = (ExerciseStatus)status;

            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var exercise = await _repository.GetByIdAsync(id);
            if (exercise != null)
            {
                _repository.Delete(exercise);
                await _repository.SaveChangesAsync();
            }
        }
        public async Task<List<CalendarDayDto>> GetMonthExercises(int year, int month)
        {
            var exercises =
                await _repository.GetByMonth(year, month);
            return exercises
                .GroupBy(e => e.ExerciseDate)
                .Select(g => new CalendarDayDto
                {
                    Date = g.Key,
                    Exercises = g.Select(e => new CalendarExerciseDto
                    {
                        Name = e.ExerciseType.Name,
                        ProgressValue = e.ProgressValue,
                        Unit = e.ExerciseType.ProgressUnit
                    }).ToList()
                })
                .ToList();
            /*return exercises
                .GroupBy(e => e.ExerciseDate)
                .Select(g => new CalendarDayDto
                {
                    Date = g.Key,
                    Exercises = g.Select(e =>
                        e.ExerciseType.Name).ToList()
                })
                .ToList();*/
        }
        /*public async Task AddAsync(Exercise exercise)
        {
            await _repository.AddAsync(exercise);
            await _repository.SaveChangesAsync();
        }+
        public async Task UpdateAsync(Exercise exercise)
        {
            _repository.Update(exercise);
            await _repository.SaveChangesAsync();
        }*/
    }
}
