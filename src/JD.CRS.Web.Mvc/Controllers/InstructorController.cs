using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Instructor;
using JD.CRS.Instructor.Dto;
using JD.CRS.Web.Models.Instructor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Instructor)]
    public class InstructorController : CRSControllerBase
    {
        private readonly IInstructorAppService _instructorAppService;
        public InstructorController(IInstructorAppService instructorAppService)
        {
            _instructorAppService = instructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<InstructorReadDto> output = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {
                
            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int instructorId)
        {
            var instructor = await _instructorAppService.Get(new EntityDto<int>(instructorId));
            var model = new Edit
            {
                Instructor = instructor,
                Status = instructor.Status
            };
            return View("Edit", model);
        }
    }
}