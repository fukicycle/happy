using Microsoft.AspNetCore.Components;

namespace frontend.Pages
{
    public class PageBase : ComponentBase, IDisposable
    {
        private readonly IStateContainer _stateContainer;
        public PageBase(IStateContainer stateContainer)
        {
            _stateContainer = stateContainer;
        }

        protected override void OnInitialized()
        {
            _stateContainer.OnStateChanged += StateHasChanged;
        }
        public void Dispose()
        {
            _stateContainer.OnStateChanged -= StateHasChanged;
        }
    }
}
