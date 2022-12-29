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
        public const string SectorServiceURL = "http://51.77.140.61:10000/";
        public const string AuthenticationServiceURL = "http://51.77.140.61:10001/";
        public const string MqttDefaultTopic = "sos";
        public const string MqttBrokerAddress = "51.77.140.61";
        public const int MqttBrokerPort = 1883;
        public const int RequestTimeout = 30000;
        public const int SectorRefreshDelay = 5000;
    }
}
