using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.Dtos.Requests;
using Module5HW1.Dtos.Responses;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class AutorizeService : IAutorizeService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<AutorizeService> _logger;
        private readonly ApiOption _options;
        private readonly string _registerApi = "api/register";
        private readonly string _loginApi = "api/login";

        public AutorizeService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<AutorizeService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<AutorizeResponse> Login(string email, string password)
        {
            var result = await _httpClientService.SendAsync<AutorizeResponse, AutorizeRequest>(
           $"{_options.Host}{_loginApi}",
           HttpMethod.Post,
           new AutorizeRequest()
           {
               Email = email,
               Password = password!
           });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result?.Id} was logined");
            }
            else
            {
                _logger.LogInformation($"User with id = {result?.Id} was not logined");
            }

            return result!;
        }

        public async Task<AutorizeResponse> Register(string email, string? password)
        {
            var result = await _httpClientService.SendAsync<AutorizeResponse, AutorizeRequest>(
           $"{_options.Host}{_registerApi}",
           HttpMethod.Post,
           new AutorizeRequest()
           {
               Email = email,
               Password = password!
           });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result?.Id} was registered");
            }
            else
            {
                _logger.LogInformation($"User with id = {result?.Id} was not registered");
            }

            return result!;
        }
    }
}
