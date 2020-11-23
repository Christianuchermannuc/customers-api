using EventFunction;
using EventFunction.Entities;
using EventFunction.Models;
using EventFunction.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Startup))]
namespace EventFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            var con = "Server=tcp:abhlnuz2at.database.windows.net,1433;Initial Catalog=customerEventAzureDb;Persist Security Info=False;User ID=ucforecast;Password=Berlin..77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<CustomerEventContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, con));

            builder.Services.AddTransient<IEventRepository, EventRepository>();
        }
    }   
}
