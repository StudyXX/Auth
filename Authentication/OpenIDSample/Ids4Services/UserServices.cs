using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ids4Services
{
    public class UserServices
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "aaa",
                    Password = "pwd"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bbb",
                    Password = "pwd",
                }
            };
        }
    }
}
