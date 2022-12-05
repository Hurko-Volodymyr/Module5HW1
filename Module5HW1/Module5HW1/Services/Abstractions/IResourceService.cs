using Module5HW1.Dtos.Responses;
using Module5HW1.Dtos;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ResourceDto?> GetResourceById(int id);
        Task<ListResponse<ResourceDto>> GetListResoursesByPage(int page);
    }
}