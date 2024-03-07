namespace Happy.Shared.Dto.Request;

public class GoalRequestDto
{
    public GoalRequestDto(string content, int point)
    {
        Content = content;
        Point = point;
    }
    public string Content { get; }
    public int Point { get; }
}