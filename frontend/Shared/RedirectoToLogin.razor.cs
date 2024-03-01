
namespace Happy.frontend.Shared
{
    public partial class RedirectoToLogin
    {
        protected override async Task OnInitializedAsync()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}
