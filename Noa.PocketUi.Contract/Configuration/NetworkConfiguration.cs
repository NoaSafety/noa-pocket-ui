using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Noa.PocketUi.Contract.Configuration
{
    public class NetworkConfiguration
    {
        public NetworkConfiguration(string ssid, string psk, string encryption, string ip, string gateway, string dns)
        {
            Ssid = ssid;
            Psk = psk;
            Encryption = encryption;
            Ip = ip;
            Gateway = gateway;
            Dns = dns;
        }

        [JsonPropertyName("ssid")]
        public string Ssid { get; set; }

        [JsonPropertyName("psk")]
        public string Psk { get; set; }

        [JsonPropertyName("key_mgmt")]
        public string Encryption { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("gateway")]
        public string Gateway { get; set; }

        [JsonPropertyName("dns")]
        public string Dns { get; set; }
    }
}
