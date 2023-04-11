using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ECommerceContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ECommerceContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<Role> GetRoles(User user)
        {
            using (var context = new ECommerceContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                                 on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, Name = role.Name };
                return result.ToList();
            }
        }


    }
}
