using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Configuration
{
    public class NOAConfiguration
    {
        public const string ServiceName = "PocketUI";
        public const string SectorServiceURL = "http://noa.broker:10000/sector/";
        public const string MqttDefaultTopic = "sos";
        public const string MqttBrokerAddress = "noa.broker";
        public const int MqttBrokerPort = 1883;
        public const int RequestTimeout = 5000;
        public const int SectorRefreshDelay = 5000;
    }
}
