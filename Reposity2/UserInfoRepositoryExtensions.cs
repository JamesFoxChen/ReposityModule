using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReposityModule.Reposity2
{
    public static class UserInfoRepositoryExtensions
    {
        public static UserInfo GetSingleByUsername(
            this IEntityRepository<UserInfo> userRepository, string username)
        {            
            return userRepository.GetAll().FirstOrDefault(x => x.Name == username);
        }
    }
}
