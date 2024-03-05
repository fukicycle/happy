using Happy.frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Happy.frontend.Shared
{
    public partial class ApiAuthentication
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "redirect")]
        public string? Redirect { get; set; }
        protected override async Task OnInitializedAsync()
        {
            string? email = await LocalStorageService.GetItemAsStringAsync("EMAIL");
            if (email == null)
            {
                NavigationManager.NavigateTo("login");
                return;
            }
            string token = await LoginService.LoginAsync(email);
            if (token == string.Empty)
            {
                NavigationManager.NavigateTo("login");
                return;
            }
            HttpClientService.SetAuthorizationToken(token);
            if (Redirect == null)
            {
                NavigationManager.NavigateTo("home");
            }
            else
            {
                NavigationManager.NavigateTo(Redirect);
            }
        }
    }
}
