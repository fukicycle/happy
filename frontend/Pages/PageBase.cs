using Microsoft.AspNetCore.Components;

namespace frontend.Pages
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        public IStateContainer StateContainer { get; private set; } = null!;
        protected override void OnInitialized()
        {
            StateContainer.OnStateChanged += StateHasChanged;
        }
        public void Dispose()
        {
            StateContainer.OnStateChanged -= StateHasChanged;
        }
    }
}
