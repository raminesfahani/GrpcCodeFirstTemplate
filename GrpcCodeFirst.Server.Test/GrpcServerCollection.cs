using Xunit;

namespace GrpcCodeFirst.Server.Test
{
    [CollectionDefinition(CollectionFixtureType.GrpcServer)]
    public class GrpcServerCollection: ICollectionFixture<TestServerFixture>
    {
        
    }
}