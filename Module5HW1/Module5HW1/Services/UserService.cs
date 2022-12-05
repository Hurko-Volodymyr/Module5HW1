using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.Dtos;
using Module5HW1.Dtos.Requests;
using Module5HW1.Dtos.Responses;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<UserDto?> GetUserById(int id)
    {
      var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}/{id}", HttpMethod.Get);

      if (result?.Data != null)
      {
          _logger.LogInformation($"User with id = {result.Data.Id} was found");
      }
      else
      {
          _logger.LogInformation($"User with id = {result?.Data.Id} was not found");
      }

      return result?.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new UserRequest()
        {
            Job = job,
            Name = name
        });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was created");
        }

        return result!;
    }

    public async Task<ListResponse<UserDto>> GetListUsersByPage(int page)
    {
        var result = await _httpClientService.SendAsync<ListResponse<UserDto>, object>($"{_options.Host}{_userApi}?page{page}", HttpMethod.Get);

        if (result != null)
        {
            _logger.LogInformation($"Users with page = {page} was found");
        }
        else
        {
            _logger.LogInformation($"Users with page = {page} was not found");
        }

        return result!;
    }

    public async Task<UserResponse> UpdateUser(int id, string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}/{id}",
            HttpMethod.Put,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was updated");
        }

        return result!;
    }
}