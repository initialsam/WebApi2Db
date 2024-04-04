namespace MDB2Repository;

using Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.Reflection;


public class MDB2Context : DbContext
{
    public MDB2Context()
    {

    }

    public MDB2Context(string connectionString) : base(
    new DbContextOptionsBuilder<MDB2Context>()
    .UseSqlServer(connectionString,
        builder =>
        {

        })
    //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .Options)
    {
        //this.Database.SetCommandTimeout(300);

    }

    public MDB2Context(DbContextOptions<MDB2Context> options)
      : base(options)
    {
        //this.Database.SetCommandTimeout(300);
    }

    public class MDB2ContextFactory : IDesignTimeDbContextFactory<MDB2Context>
    {
        public MDB2Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                  .AddJsonFile($"appsettings.{args[1]}.json", optional: false)
                  .Build();
            var sqlConnection = configuration.GetValue<string>(Constants.ApiAppsettings.ConnectionStrings.SqlConnection2);
            var optionsBuilder = new DbContextOptionsBuilder<MDB2Context>();
            optionsBuilder.UseSqlServer(sqlConnection,
            builder =>
            {

            });
            return new MDB2Context(optionsBuilder.Options);
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
