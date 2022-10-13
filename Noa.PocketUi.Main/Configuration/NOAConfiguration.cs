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
        public const string LocationServiceURL = "https://api.noa.broker";
        public const string MqttDefaultTopic = "sos";
        public const string MqttBrokerAddress = "51.77.140.61";
        public const int MqttBrokerPort = 1883;
        public const int RequestTimeout = 5000;
    }
}
