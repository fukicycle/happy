
namespace frontend
{
    public sealed class StateContainer : IStateContainer
    {
        public string Message { get; private set; } = null!;

        public bool IsLoading { get; private set; } = false;

        public event Action OnMessageChanged = null!;
        public event Action OnLoadingStateChanged = null!;

        public void ClearMessage()
        {
            Message = string.Empty;
            NotifyMessageChanged();
        }

        public void SetLoadingState(bool isLoading)
        {
            IsLoading = isLoading;
            NotifyLoadingChanged();
        }

        public void SetMessage(string message)
        {
            Message = message;
            NotifyMessageChanged();
        }

        private void NotifyMessageChanged() => OnMessageChanged.Invoke();
        private void NotifyLoadingChanged() => OnLoadingStateChanged.Invoke();
    }
}
