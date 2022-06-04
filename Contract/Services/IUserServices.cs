

using System.ServiceModel;
using System.Threading.Tasks;
using Contract.Models;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Contract.Services
{
    [ServiceContract]
    public interface IUserServices
    {
        Task<Response> CreateUser(UserInformation userInformation, CallContext callContext = default);
    }
}