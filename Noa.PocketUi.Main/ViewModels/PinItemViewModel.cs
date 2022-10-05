using Position = Microsoft.Maui.Devices.Sensors.Location;


namespace Noa.PocketUi.Main.ViewModels;

public class PinItemViewModel : BaseViewModel
{
    private Position _position;
    public string Label { get; }
    public string Description { get; }

    public Position Position { get; set; }

    public PinItemViewModel(string label, string description, Position position)
    {
        Label = label;
        Description = description;
        Position = position;
    }
}
