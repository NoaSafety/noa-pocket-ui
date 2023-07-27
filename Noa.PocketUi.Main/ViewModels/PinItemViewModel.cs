using Position = Microsoft.Maui.Devices.Sensors.Location;

namespace Noa.PocketUi.Main.ViewModels;

public class PinItemViewModel : BaseViewModel
{
    public string Label { get; }
    public string Description { get; }

    public Position Position { get; set; }
    public UInt32 Timestamp { get; set; }

    public PinItemViewModel(string label, string description, Position position, UInt32 timestamp)
    {
        Label = label;
        Description = description;
        Position = position;
        Timestamp = timestamp;
    }
}
