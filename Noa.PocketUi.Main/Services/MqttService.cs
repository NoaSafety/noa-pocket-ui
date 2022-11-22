using MQTTnet;
using MQTTnet.Client;
using Noa.PocketUi.Main.Helpers;
using Noa.PocketUi.Main.Configuration;
using MQTTnet.Packets;
using MQTTnet.Server;
using Noa.PocketUi.Contract.Location;
using System;
using System.Text.Json;

namespace Noa.PocketUi.Main.Services;

public class MqttService : IMqttService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMqttClient _mqttClient;
    private readonly MqttMessageDirector _mqttMessageDirector;
    private Action<SOSCall> _SOSCallback;

    public MqttService(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        _mqttClient = new MqttFactory().CreateMqttClient();
        _mqttMessageDirector = new MqttMessageDirector();
        _mqttClient.ApplicationMessageReceivedAsync += e =>
        {
            var text = e.ApplicationMessage.ConvertPayloadToString();
            var sosCall = JsonSerializer.Deserialize<SOSCall>(text);
            _SOSCallback(sosCall);
            return Task.CompletedTask;
        };
    }

    public void ConfigureSOSCallback(Action<SOSCall> SOSCallback) => _SOSCallback = SOSCallback;
    public async Task ResetAndSubscribeAsync(List<string> sectors)
    {
        if(_mqttClient.IsConnected)
        {
            await _mqttClient.UnsubscribeAsync(new MqttClientUnsubscribeOptions()
            {
                TopicFilters = new() { "*" }
            });
            await _mqttClient.SubscribeAsync(new MqttClientSubscribeOptions()
            {
                TopicFilters = sectors.Select(s => new MqttTopicFilter
                {
                    Topic = $"noa/{s}/alerts"
                }).ToList()
            });
        }
    }

    public async Task SendSosAsync(Location location, string sector = NOAConfiguration.MqttDefaultTopic)
    {
        await EnsureMQTTConnectionAsync();
        var sos = _mqttMessageDirector.BuildSOSCall(_authenticationService.GetUserId(), $"noa/{sector}/alerts", location.Latitude, location.Longitude);
        await _mqttClient.PublishAsync(sos);    
    }

    private async Task EnsureMQTTConnectionAsync()
    {
        if(!_mqttClient.IsConnected)
        {
            await _mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
            .WithClientId(_authenticationService.GetUserId().ToString())
            .WithTcpServer(NOAConfiguration.MqttBrokerAddress, NOAConfiguration.MqttBrokerPort)
            .WithTls()
            .WithCleanSession()
            .Build());
        }
    }
}
