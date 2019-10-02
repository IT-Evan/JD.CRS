using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JD.CRS.Entitys;
using JD.CRS.Course.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JD.CRS.Course
{

    public class CourseAppService : AsyncCrudAppService<Entitys.Course, CourseDto, int, PagedResultRequestDto,
                             CreateUpdateCourseDto, CreateUpdateCourseDto>, ICourseAppService

    {

        public CourseAppService(IRepository<Entitys.Course, int> repository)
            : base(repository)
        {

        }

        public override Task<CourseDto> Create(CreateUpdateCourseDto input)
        {
            var sin = input;
            return base.Create(input);
        }
    }
}