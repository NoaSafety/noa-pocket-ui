using MQTTnet;
using MQTTnet.Client;
using Noa.PocketUi.Main.Helpers;
using Noa.PocketUi.Main.Configuration;

namespace Noa.PocketUi.Main.Services;

public class MqttService : IMqttService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMqttClient _mqttClient;
    private readonly MqttMessageDirector _mqttMessageDirector;

    public MqttService(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        _mqttClient = new MqttFactory().CreateMqttClient();
        _mqttMessageDirector = new MqttMessageDirector();
    }

    public async Task SendSosAsync(Location location, string sector = NOAConfiguration.MqttDefaultTopic)
    {
        await EnsureMQTTConnectionAsync();
        var sos = _mqttMessageDirector.BuildSOSCall(_authenticationService.GetUserId(), sector, location.Latitude, location.Longitude);
        await _mqttClient.PublishAsync(sos);    
    }

    private async Task EnsureMQTTConnectionAsync()
    {
        if(!_mqttClient.IsConnected)
        {
            await _mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
            .WithClientId(_authenticationService.GetUserId().ToString())
            .WithTcpServer(NOAConfiguration.MqttBrokerAddress, NOAConfiguration.MqttBrokerPort)
            .WithCleanSession()
            .Build());
        }
    }
}
