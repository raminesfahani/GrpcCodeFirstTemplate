using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace Contract.Models
{
    [ProtoContract]
    public class UserInformation
    {
        [ProtoMember(1)]
        public string FirstName { get; set; } = String.Empty;
    
        [DataMember(Order = 2)]
        public string LastName { get; set; } = String.Empty;
    
        [DataMember(Order = 3)]
        public string Password { get; set; } = String.Empty;
    
        [DataMember(Order = 4)]
        public int Age { get; set; }
    
        public UserInformation()
        {
            
        }
    
        public UserInformation(string firstName, string lastName, string password, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Age = age; 
        }
    }
}
