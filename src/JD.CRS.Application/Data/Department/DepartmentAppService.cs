using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.Department.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.Department
{
    public class DepartmentAppService : AsyncCrudAppService<Entitys.Department, DepartmentReadDto, int, PagedResultRequestDto,// GetAllDepartmentsInput,
                             DepartmentWriteDto, DepartmentWriteDto>, IDepartmentAppService

    {
        private readonly IRepository<Entitys.Department, int> _DepartmentRepository;
        public DepartmentAppService(IRepository<Entitys.Department, int> DepartmentRepository)
            : base(DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public override Task<DepartmentReadDto> Create(DepartmentWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<DepartmentReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var Departmentcount = query.Count();
            //获取清单
            var Departmentlist = query.ToList();

            return new PagedResultDto<DepartmentReadDto>()
            {
                TotalCount = Departmentcount,
                Items = ObjectMapper.Map<List<DepartmentReadDto>>(Departmentlist)
            };
        }
    }
}