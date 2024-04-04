using Common;

using MDB1Repository;

using MDB2Repository;

using Microsoft.EntityFrameworkCore;

namespace WebApi2Db
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var sqlConnection1 = builder.Configuration.GetValue<string>(Constants.ApiAppsettings.ConnectionStrings.SqlConnection1);
            builder.Services.AddDbContext<MDB1Context>(
                opt => opt.UseSqlServer(
                    sqlConnection1,
                    builder =>
                    {
                    })
               .LogTo(Console.WriteLine,
                       new[] { DbLoggerCategory.Database.Command.Name },
                       LogLevel.Information)
               .EnableSensitiveDataLogging()
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            var sqlConnection2 = builder.Configuration.GetValue<string>(Constants.ApiAppsettings.ConnectionStrings.SqlConnection2);
            builder.Services.AddDbContext<MDB2Context>(
                opt => opt.UseSqlServer(
                    sqlConnection2,
                    builder =>
                    {
                    })
               .LogTo(Console.WriteLine,
                       new[] { DbLoggerCategory.Database.Command.Name },
                       LogLevel.Information)
               .EnableSensitiveDataLogging()
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            //Repository
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Repository
            builder.Services.AddScoped<IUnitOfWork2, UnitOfWork2>();
            builder.Services.AddScoped(typeof(IGenericRepository2<>), typeof(GenericRepository2<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
