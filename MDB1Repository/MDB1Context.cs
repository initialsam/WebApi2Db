using Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.Reflection;

namespace MDB1Repository;

public class MDB1Context : DbContext
{
    public MDB1Context()
    {
        
    }

    public MDB1Context(string connectionString) : base(
    new DbContextOptionsBuilder<MDB1Context>()
    .UseSqlServer(connectionString,
        builder =>
        {

        })
    //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .Options)
    {
        //this.Database.SetCommandTimeout(300);

    }

    public MDB1Context(DbContextOptions<MDB1Context> options)
      : base(options)
    {
        //this.Database.SetCommandTimeout(300);
    }

    public class MDB1ContextFactory : IDesignTimeDbContextFactory<MDB1Context>
    {
        public MDB1Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                  .AddJsonFile($"appsettings.{args[1]}.json", optional: false)
                  .Build();
            var sqlConnection = configuration.GetValue<string>(Constants.ApiAppsettings.ConnectionStrings.SqlConnection1);
            var optionsBuilder = new DbContextOptionsBuilder<MDB1Context>();
            optionsBuilder.UseSqlServer(sqlConnection,
            builder =>
            {

            });
            return new MDB1Context(optionsBuilder.Options);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //載入 Mapping 的所有設定
        var a = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(a);
    }
    public void MigrateAndSeedData()
    {
        this.Database.Migrate();
        //SeedData();
    }
}
