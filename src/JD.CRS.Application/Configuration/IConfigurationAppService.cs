using System.Threading.Tasks;
using JD.CRS.Configuration.Dto;

namespace JD.CRS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
