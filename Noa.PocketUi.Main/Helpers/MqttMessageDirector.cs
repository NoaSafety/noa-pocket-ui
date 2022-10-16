using MQTTnet;
using MQTTnet.Client;
using Noa.PocketUi.Contract.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Helpers;

public class MqttMessageDirector
{
    private readonly MqttApplicationMessageBuilder _builder;

    public MqttMessageDirector()
    {
        _builder = new MqttApplicationMessageBuilder();
    }

    public MqttApplicationMessage BuildSOSCall(Guid userId, string topic, double latitude, double longitude)
    {
        var payload = JsonSerializer.Serialize(new SOSCall()
        {
            UserId = userId,
            Coordinates = new GPSCoordinates()
            {
                Latitude = latitude,
                Longitude = longitude
            },
            Timestamp = TimeSpan.FromTicks(DateTime.Now.Ticks)
        });

        return _builder
            .WithTopic(topic)
            .WithPayload(payload)
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
            .Build();
    }
}
