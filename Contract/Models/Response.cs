using System;
using ProtoBuf;

namespace Contract.Models
{
    [ProtoContract]
    public class Response
    {
        [ProtoMember(1)]
        public bool Success { get; set; }

        [Obsolete("You must create instance of this class with another constructor with require parameter", true)]
        public Response()
        {
            
        }
        
        public Response(bool success)
        {
            Success = success;
        }
        
        public static Response IsFailed()
        {
            return new Response(false);
        }
        
        public static Response IsSuccessful()
        {
            return new Response(true);
        }
    }
}