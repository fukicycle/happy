﻿using frontend.Components;

namespace frontend.Shared
{
    public partial class MainLayout : IDisposable
    {
        private Dialog DialogInstance { get; set; } = null!;
        protected override void OnInitialized()
        {
            StateContainer.OnStateChanged += OnStateChanged;
        }

        private void OnStateChanged()
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
            StateContainer.OnStateChanged -= OnStateChanged;
        }
    }
}
