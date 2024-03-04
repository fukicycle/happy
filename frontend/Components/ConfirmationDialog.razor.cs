using Microsoft.AspNetCore.Components;

namespace Happy.frontend.Components
{
    public partial class ConfirmationDialog
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public string Message { get; set; } = string.Empty;

        [Parameter]
        public EventCallback CancelButtoOnClick { get; set; }

        private string _displayChangeStyle = "display: none;";

        public void OkClose()
        {
            Title = string.Empty;
            Message = string.Empty;
            _displayChangeStyle = "display: none;";
        }

        public async Task CacnelClose()
        {
            await CancelButtoOnClick.InvokeAsync();
            Title = string.Empty;
            Message = string.Empty;
            _displayChangeStyle = "display: none;";
        }

        public void Open()
        {
            _displayChangeStyle = "display: flex;";
        }
    }
}
