
namespace Happy.frontend.Shared
{
    public partial class RedirectoToLogin
    {
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}
