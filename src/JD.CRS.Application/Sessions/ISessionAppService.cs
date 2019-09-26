using System.Threading.Tasks;
using Abp.Application.Services;
using JD.CRS.Sessions.Dto;

namespace JD.CRS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
