using Module5HW1.Dtos;
using Module5HW1.Dtos.Responses;

namespace Module5HW1.Services.Abstractions;

public interface IUserService
{
    Task<UserDto?> GetUserById(int id);
    Task<ListResponse<UserDto>> GetListUsersByPage(int page);
    Task<UserResponse> CreateUser(string name, string job);
    Task<UserResponse> UpdateUser(int id, string name, string job);
}