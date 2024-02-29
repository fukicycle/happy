using Microsoft.AspNetCore.Components;

namespace frontend.Pages
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        public IStateContainer StateContainer { get; private set; } = null!;
        protected override void OnInitialized()
        {
            StateContainer.OnMessageChanged += StateHasChanged;
            StateContainer.OnLoadingStateChanged += StateHasChanged;
        }
        public void Dispose()
        {
            StateContainer.OnMessageChanged -= StateHasChanged;
            StateContainer.OnLoadingStateChanged -= StateHasChanged;
        }
    }
}
