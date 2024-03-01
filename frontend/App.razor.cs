
namespace Happy.frontend
{
    public partial class App
    {
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("api-auth");
        }
    }
}
