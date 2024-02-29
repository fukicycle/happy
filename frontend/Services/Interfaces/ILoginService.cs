namespace Happy.frontend.Services.Interfaces
{
    public interface ILoginService
    {
        Task GetApiTokenAsync(string email);
    }
}