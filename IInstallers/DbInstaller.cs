using System;
using Microsoft.AspNetCore.Identity;
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
            services.AddSingleton<ITaskService,TaskService >();
        }
    }
}
