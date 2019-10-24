using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Department;
using JD.CRS.Department.Dto;
using JD.CRS.Web.Models.Department;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Department)]
    public class DepartmentController : CRSControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;
        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<DepartmentReadDto> output = (await _departmentAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {
                
            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentId)
        {
            var department = await _departmentAppService.Get(new EntityDto<int>(departmentId));
            var model = new Edit
            {
                Department = department,
                Status = department.Status
            };
            return View("Edit", model);
        }
    }
}