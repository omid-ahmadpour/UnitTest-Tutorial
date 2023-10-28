namespace UnitTestTutorial.Persistence
{
    using UnitTestTutorial.Persistence.Db;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        public AppDbContextFactory()
        { }

        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
