namespace Noa.PocketUi.Contract.Location;

public class SOSCall
{
    public Guid UserId { get; set; }
    public GPSCoordinates Coordinates { get; set; }
    public TimeSpan Timestamp { get; set; }
}