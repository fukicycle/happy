using Happy.Shared.ValueObjects;

namespace Happy.frontend.Models;

public sealed class UserPoint
{
    public UserPoint(int yesterdayPoint, int totalPoint)
    {
        YesterdayPoint = new Point(yesterdayPoint);
        TotalPoint = new Point(totalPoint);

    }
    public Point YesterdayPoint { get; }
    public Point TotalPoint { get; }
}