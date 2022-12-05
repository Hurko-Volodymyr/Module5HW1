using Newtonsoft.Json;

namespace Module5HW1.Dtos.Responses;

public class BaseResponse<T>
    where T : class
{
    public T Data { get; set; } = null!;
    public SupportDto Support { get; set; } = null!;
}