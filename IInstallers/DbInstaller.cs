using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Data;
using ToDoApp.Services;

namespace ToDoApp.IInstallers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
        services.AddDbContext<DataContext>(opt =>
            {

                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddScoped<ITaskService,TaskService >();
        }
    }
}
