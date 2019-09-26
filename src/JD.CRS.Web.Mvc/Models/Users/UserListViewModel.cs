using System.Collections.Generic;
using JD.CRS.Roles.Dto;
using JD.CRS.Users.Dto;

namespace JD.CRS.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
