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
            await LoginService.GetApiTokenAsync(email);
            NavigationManager.NavigateTo("home");
        }
    }
}
