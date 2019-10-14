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
    public class DepartmentAppService : AsyncCrudAppService<Entitys.Department, DepartmentDto, int, PagedResultRequestDto,// GetAllDepartmentsInput,
                             CreateUpdateDepartmentDto, CreateUpdateDepartmentDto>, IDepartmentAppService

    {
        private readonly IRepository<Entitys.Department, int> _DepartmentRepository;
        public DepartmentAppService(IRepository<Entitys.Department, int> DepartmentRepository)
            : base(DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public override Task<DepartmentDto> Create(CreateUpdateDepartmentDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<DepartmentDto>> GetAll(PagedResultRequestDto input)//(GetAllDepartmentsInput input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var Departmentcount = query.Count();
            //获取清单
            var Departmentlist = query.ToList();

            //return new PagedResultDto<DepartmentDto>(Departmentcount, Departmentlist.MapTo<List<DepartmentDto>>());
            return new PagedResultDto<DepartmentDto>()
            {
                TotalCount = Departmentcount,
                Items = ObjectMapper.Map<List<DepartmentDto>>(Departmentlist)
            };
        }
    }
}