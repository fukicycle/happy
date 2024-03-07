namespace Happy.Shared.Dto.Request;

public class GoalRequestDto
{
    public GoalRequestDto(string content, int point, string email)
    {
        Content = content;
        Point = point;
        Email = email;
    }
    public string Content { get; }
    public int Point { get; }
    public string Email { get; }
}