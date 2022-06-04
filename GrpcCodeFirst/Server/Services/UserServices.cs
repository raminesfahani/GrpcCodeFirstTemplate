
using System.Threading.Tasks;
using Contract.Models;
using Contract.Services;
using ProtoBuf.Grpc;

namespace GrpcCodeFirst.Server.Services
{
    public class UserServices: IUserServices
    {
        public Task<Response> CreateUser(UserInformation userInformation, CallContext callContext = default)
        {
            if (userInformation.FirstName == string.Empty && userInformation.LastName == string.Empty)
            {
                return Task.FromResult(Response.IsFailed());
            }
            
            return Task.FromResult(Response.IsSuccessful());
        }
    }
}