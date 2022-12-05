namespace Module5HW1.Dtos.Responses;

public class UserResponse
{
    public string Name { get; set; } = null!;
    public string Job { get; set; } = null!;
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}