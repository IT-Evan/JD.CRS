using System.Collections.Generic;
using JD.CRS.Roles.Dto;

namespace JD.CRS.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}