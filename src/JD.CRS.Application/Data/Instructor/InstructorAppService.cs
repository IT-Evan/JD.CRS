using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.Instructor.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.Instructor
{
    public class InstructorAppService : AsyncCrudAppService<Entitys.Instructor, InstructorReadDto, int, PagedResultRequestDto,// GetAllInstructorsInput,
                             InstructorWriteDto, InstructorWriteDto>, IInstructorAppService

    {
        private readonly IRepository<Entitys.Instructor, int> _InstructorRepository;
        public InstructorAppService(IRepository<Entitys.Instructor, int> InstructorRepository)
            : base(InstructorRepository)
        {
            _InstructorRepository = InstructorRepository;
        }

        public override Task<InstructorReadDto> Create(InstructorWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<InstructorReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var Instructorcount = query.Count();
            //获取清单
            var Instructorlist = query.ToList();

            return new PagedResultDto<InstructorReadDto>()
            {
                TotalCount = Instructorcount,
                Items = ObjectMapper.Map<List<InstructorReadDto>>(Instructorlist)
            };
        }
    }
}