using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Contract.Models;
using Contract.Services;
using Grpc.Net.Client;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using Xunit;

namespace GrpcCodeFirst.Server.Test
{
    [Collection(CollectionFixtureType.GrpcServer)]
    public class UserServicesTest
    {
        #region Private fields
        private readonly IUserServices _userServices;
        private readonly TestServerFixture _testServerFixture;
        #endregion
        
        public UserServicesTest(TestServerFixture testServerFixture)
        {
            _testServerFixture = testServerFixture;
            GrpcChannel channel = testServerFixture.GrpcChannel;
            _userServices = channel.CreateGrpcService<IUserServices>();
        }
        
        
        [Theory, AutoData]
        public async Task CreateUser_UserInValid_CreatedAndReturnSuccessResponse(UserInformation userInformation)
        {
            // Act
            Response response = await _userServices.CreateUser(userInformation, CallContext.Default);
            
            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }
    }
}