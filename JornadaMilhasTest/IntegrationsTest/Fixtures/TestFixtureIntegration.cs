using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.IntegrationsTest.Helper;
using JornadaMilhasTest.IntegrationsTest.WebApplicationFactory;
using Microsoft.EntityFrameworkCore;


namespace JornadaMilhasTest.IntegrationsTest.Fixtures;

public class TestFixtureIntegration
{

    #region Privates Props


    private static readonly object _lock = new();

    private static bool _databaseInitialized;

    #endregion

    public JornadaMilhasDbContext context;

    public HttpClient client;

    public TestFixtureIntegration()
    {
        PrepareTestDatabase();
        client = new WebApplicationFactoryJornada<Program>().CreateClient();
    }

    public static JornadaMilhasDbContext CreateContext() => 
        new(new DbContextOptionsBuilder<JornadaMilhasDbContext>().UseSqlServer(TestHelper.ConnectionString).Options);

    private void PrepareTestDatabase()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    this.context = context;
                }

                _databaseInitialized = true;
            }
        }
    }

    public void Dispose() => context.Dispose();

}

