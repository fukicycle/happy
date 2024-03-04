namespace Happy.frontend.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(string email);
    }
}