namespace Happy.frontend
{
    public interface IStateContainer
    {
        event Action OnLoadingStateChanged;
        bool IsLoading { get; }
        void SetLoadingState(bool isLoading);
        event Action OnMessageChanged;
        string Message { get; }
        void ClearMessage();
        void SetMessage(string message);
    }
}
