

using Application.Interfaces.Repositories;
using Infraestructure.Context;
using Infraestructure.Options;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infraestructure;

public static class DependeceInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var protechAnimesUser = Environment.GetEnvironmentVariable("AnimesProtechUser") ?? throw new ArgumentException(nameof(ProtechAnimesContextOptions.ProtechAnimesUser));
        var protechAnimesPassword = Environment.GetEnvironmentVariable("AnimesProtechPassword") ?? throw new ArgumentException(nameof(ProtechAnimesContextOptions.ProtechAnimesPassword));

        services.Configure<ProtechAnimesContextOptions>(a =>
        {
            a.ProtechAnimesUser = protechAnimesUser;
            a.ProtechAnimesPassword = protechAnimesPassword;
        });

        services.AddDbContext<ProtechAnimesContext>((sp, opt) =>
        {
            var options = sp.GetRequiredService<IOptions<ProtechAnimesContextOptions>>().Value;
            var conectionString = configuration.GetConnectionString("ProtechAnimesConnectionString");
            var fullconectionString = $"{conectionString}User ID={options.ProtechAnimesUser};Password={options.ProtechAnimesPassword};";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
            opt.UseMySql(fullconectionString, serverVersion);
        });

        services.AddScoped<IAnimeRepository, AnimeRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();

        return services;
    }
}
