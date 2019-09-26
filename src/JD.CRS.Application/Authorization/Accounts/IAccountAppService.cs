using System.Threading.Tasks;
using Abp.Application.Services;
using JD.CRS.Authorization.Accounts.Dto;

namespace JD.CRS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
