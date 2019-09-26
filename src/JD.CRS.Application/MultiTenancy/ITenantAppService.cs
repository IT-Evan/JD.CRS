using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.MultiTenancy.Dto;

namespace JD.CRS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

