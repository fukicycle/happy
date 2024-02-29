
namespace frontend
{
    public sealed class StateContainer : IStateContainer
    {
        public string Message { get; private set; } = null!;

        public event Action? OnStateChanged;

        public void ClearMessage()
        {
            Message = string.Empty;
            NotifyStateChange();
        }

        public void SetMessage(string message)
        {
            Message = message;
            NotifyStateChange();
        }

        private void NotifyStateChange() => OnStateChanged?.Invoke();
    }
}
