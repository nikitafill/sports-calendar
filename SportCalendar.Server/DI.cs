using SportCalendar.Server.Application.Interfaces;
using SportCalendar.Server.Infrastructure.Repositories;
namespace SportCalendar.Server
{
    public static class DI
    {
        public static void RegisterRepositoriesDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IExerciseRepository, ExerciseRepository>()
                .AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();
        }
    }
}
