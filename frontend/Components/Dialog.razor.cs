using Microsoft.AspNetCore.Components;

namespace frontend.Components
{
    public partial class Dialog
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public string Message { get; set; } = string.Empty;

        private string _displayChangeStyle = "display: none;";

        public void Close()
        {
            _displayChangeStyle = "display: none;";
        }

        public void Open()
        {
            _displayChangeStyle = "display: block;";
        }
    }
}
