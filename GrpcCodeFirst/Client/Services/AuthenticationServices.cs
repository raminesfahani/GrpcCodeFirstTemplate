using System;
using System.Threading.Tasks;
using Contract.Models;
using Contract.Services;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace GrpcCodeFirst.Client.Services
{
    public class AuthenticationServices
    {
        private readonly GrpcChannel _grpcChannel;
        
        public AuthenticationServices(GrpcChannel grpcChannel)
        {
            _grpcChannel = grpcChannel;
        }
        
        public async Task<Response> CreateUser(UserInformation userInformation)
        {
            IUserServices client = _grpcChannel.CreateGrpcService<IUserServices>();
            Response response = await client.CreateUser(userInformation);
            return response;
        }
    }
}