
namespace Happy.frontend.Shared
{
    public partial class RedirectoToLogin
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(2000);
            NavigationManager.NavigateTo("login");
        }
    }
}
