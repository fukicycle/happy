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
        public EventCallback OkButtonOnClick { get; set; }

        private string _displayChangeStyle = "display: none;";

        public async Task OkClose()
        {
            await OkButtonOnClick.InvokeAsync();
            Title = string.Empty;
            Message = string.Empty;
            _displayChangeStyle = "display: none;";
        }

        public void CacnelClose()
        {
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
