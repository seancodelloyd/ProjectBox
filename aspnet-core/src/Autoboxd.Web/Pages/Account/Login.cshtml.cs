using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web.Pages.Account;

namespace Autoboxd.Web.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        public CustomLoginModel(
            Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider schemeProvider,
            IOptions<Volo.Abp.Account.Web.AbpAccountOptions> accountOptions,
            IOptions<IdentityOptions> identityOptions)
            : base(schemeProvider: schemeProvider, accountOptions: accountOptions, identityOptions: identityOptions)
        {
        }
    }
}
