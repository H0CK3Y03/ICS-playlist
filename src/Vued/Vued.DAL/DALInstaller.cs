using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vued.DAL.Factories;
using Vued.DAL.UnitOfWork;

namespace Vued.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddDbContextFactory<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=app.db;Cache=Shared");
        });

        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

        return services;
    }
}
