﻿using Microsoft.AspNetCore.Components;

namespace Happy.frontend.Components
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
