using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Student;
using JD.CRS.Student.Dto;
using JD.CRS.Web.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Student)]
    public class StudentController : CRSControllerBase
    {
        private readonly IStudentAppService _studentAppService;
        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)//(GetAllStudentsInput input)
        {
            IReadOnlyList<StudentReadDto> output = (await _studentAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {
                
            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int studentId)
        {
            var student = await _studentAppService.Get(new EntityDto<int>(studentId));
            var model = new Edit
            {
                Student = student,
                Status = student.Status
            };
            return View("Edit", model);
        }
    }
}