using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.Office.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.Office
{
    public class OfficeAppService : AsyncCrudAppService<Entitys.Office, OfficeReadDto, int, PagedResultRequestDto,// GetAllOfficesInput,
                             OfficeWriteDto, OfficeWriteDto>, IOfficeAppService

    {
        private readonly IRepository<Entitys.Office, int> _OfficeRepository;
        public OfficeAppService(IRepository<Entitys.Office, int> OfficeRepository)
            : base(OfficeRepository)
        {
            _OfficeRepository = OfficeRepository;
        }

        public override Task<OfficeReadDto> Create(OfficeWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<OfficeReadDto>> GetAll(PagedResultRequestDto input)//(GetAllOfficesInput input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var Officecount = query.Count();
            //获取清单
            var Officelist = query.ToList();

            //return new PagedResultDto<OfficeDto>(Officecount, Officelist.MapTo<List<OfficeDto>>());
            return new PagedResultDto<OfficeReadDto>()
            {
                TotalCount = Officecount,
                Items = ObjectMapper.Map<List<OfficeReadDto>>(Officelist)
            };
        }
    }
}