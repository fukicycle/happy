namespace frontend
{
    public interface IStateContainer
    {
        string Message { get; }
        event Action? OnStateChanged;
        void ClearMessage();
        void SetMessage(string message);
    }
}
