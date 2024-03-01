using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;

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
                    Logger.LogWarning($"{nameof(_authenticationState)} is null");
                    return;
                }
                AuthenticationState authenticationState = await _authenticationState;
                if (authenticationState.User == null)
                {
                    Logger.LogWarning($"{nameof(authenticationState)} is null");
                    return;
                }

                if (authenticationState.User.Identity == null)
                {
                    Logger.LogWarning($"{nameof(authenticationState.User.Identity)} is null");
                    return;
                }
                if (!authenticationState.User.Identity.IsAuthenticated)
                {
                    Logger.LogWarning($"authenticationState.User.Identity.IsAuthenticated is not authenticated");
                    return;
                }
                string email = authenticationState.User.Claims.FirstOrDefault(a => a.Type == "email")?.Value ?? string.Empty;
                if (email == string.Empty)
                {
                    Logger.LogWarning($"Email is Empty");
                    return;
                }
                await LocalStorageService.SetItemAsStringAsync("EMAIL", email);
                StateContainer.SetLoadingState(false);
                await Task.Delay(2000);
                NavigationManager.NavigateTo("");
            }
            finally
            {
                StateContainer.SetLoadingState(false);
            }

        }
    }
}
