using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Happy.frontend.Pages
{
    public partial class LoginPage : PageBase
    {
        [CascadingParameter]
        private Task<AuthenticationState>? _authenticationState { get; set; }
        private void GoogleLoginButtonOnClick()
        {
            NavigationManager.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {

                StateContainer.SetLoadingState(true);
                if (_authenticationState == null)
                {
                    return;
                }
                AuthenticationState authenticationState = await _authenticationState;
                if (authenticationState.User == null)
                {
                    return;
                }

                if (authenticationState.User.Identity == null)
                {
                    return;
                }
                if (authenticationState.User.Identity.IsAuthenticated)
                {
                    StateContainer.SetLoadingState(false);
                    await Task.Delay(2000);
                    NavigationManager.NavigateTo("");
                }
            }
            finally
            {
                StateContainer.SetLoadingState(false);
            }

        }
    }
}
