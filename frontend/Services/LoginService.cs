using Happy.frontend.Services.Interfaces;
using Happy.Shared.Dto.Request;
using Happy.Shared.Dto.Response;
using Newtonsoft.Json;

namespace Happy.frontend.Services
{
    public sealed class LoginService : ILoginService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IStateContainer _stateContainer;
        public LoginService(IHttpClientService httpClientService, IStateContainer stateContainer)
        {
            _httpClientService = httpClientService;
            _stateContainer = stateContainer;
        }
        public async Task GetApiTokenAsync(string email)
        {
            try
            {
                LoginRequestDto loginRequestDto = new LoginRequestDto("sample@sample.happy.com");//demo
                string json = JsonConvert.SerializeObject(loginRequestDto);
                HttpResponseResult response = await _httpClientService.SendAsync(HttpMethod.Post, "/api/v1/login", json);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.Message);
                }
                LoginResponseDto? loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(response.Json);
                if (loginResponseDto == null)
                {
                    throw new Exception($"Desirializに失敗しました。{nameof(LoginResponseDto)}");
                }
                _httpClientService.SetAuthorizationToken(loginResponseDto.Token);
            }
            catch (Exception ex)
            {
                _stateContainer.SetMessage(ex.Message);
            }
        }
    }
}