using Module5HW1.Dtos.Responses;

namespace Module5HW1.Services.Abstractions
{
    public interface IAutorizeService
    {
        Task<AutorizeResponse> Register(string email, string? password);
        Task<AutorizeResponse> Login(string email, string password);
    }
}
