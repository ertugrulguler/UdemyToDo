using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            using var context = new TodoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(i => i.roles.Name == "Member").Select(i => new AppUser()
            {
                Id = i.user.Id,
                Name = i.user.Name,
                Surname = i.user.Surname,
                Picture = i.user.Picture,
                Email = i.user.Email,
                UserName = i.user.UserName
            }).ToList();
        }
        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, string q, int aktifSayfa = 1)
        {
            using var context = new TodoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(i => i.roles.Name == "Member").Select(i => new AppUser()
            {
                Id = i.user.Id,
                Name = i.user.Name,
                Surname = i.user.Surname,
                Picture = i.user.Picture,
                Email = i.user.Email,
                UserName = i.user.UserName
            });

            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(q))
            {
                result = result.Where(i => i.Name.ToLower().Contains(q.ToLower()) || i.Surname.ToLower().Contains(q.ToLower()));
                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((aktifSayfa - 1) * 3).Take(3);

            return result.ToList();
        }
    }
}
