using AutoFixture;
using AutoFixture.Kernel;

namespace JornadaMilhasTest.UnitsTests.Seeds;

public static class GenericSeed<TEntity>
{

    public static TEntity GetObjectTest(Fixture fixture, Func<TEntity> expressionCreateCustomObject) 
    {
        return fixture.Build<TEntity>()
            .FromFactory(expressionCreateCustomObject)
            .OmitAutoProperties()
            .Create();
    }
    
    public static IEnumerable<TEntity> GetObjectCreatedByNumberObjects(Fixture fixture, Func<TEntity> expressionCreateCustomObject, int numberOfObjects)
    {
        return fixture.Build<TEntity>()
            .FromFactory(expressionCreateCustomObject )
            .OmitAutoProperties()
            .CreateMany(numberOfObjects);
    }
}