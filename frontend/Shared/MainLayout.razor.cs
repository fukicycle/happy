﻿using Happy.frontend.Components;

namespace Happy.frontend.Shared
{
    public partial class MainLayout : IDisposable
    {
        private Dialog DialogInstance { get; set; } = null!;
        protected override void OnInitialized()
        {
            StateContainer.OnMessageChanged += OnMessageChanged;
            StateContainer.OnLoadingStateChanged += StateHasChanged;
        }

        protected override async Task OnInitializedAsync()
        {
            string? email = await LocalStorageService.GetItemAsStringAsync("EMAIL");
            if (email == null)
            {
                return;
            }
            await LoginService.GetApiTokenAsync(email);
        }

        private void OnMessageChanged()
        {
            if (DialogInstance == null)
            {
                return;
            }
            if (StateContainer.Message == string.Empty)
            {
                return;
            }
            DialogInstance.Open();
            StateHasChanged();
        }

        public void Dispose()
        {
            StateContainer.OnMessageChanged -= OnMessageChanged;
            StateContainer.OnLoadingStateChanged -= StateHasChanged;
        }
    }
}
