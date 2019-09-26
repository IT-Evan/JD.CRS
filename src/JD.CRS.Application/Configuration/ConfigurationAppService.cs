using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JD.CRS.Configuration.Dto;

namespace JD.CRS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CRSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
