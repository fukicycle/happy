using Happy.frontend.Services;

namespace Happy.frontend.Shared
{
    public partial class ApiAuthentication
    {
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
            NavigationManager.NavigateTo("home");
        }
    }
}
