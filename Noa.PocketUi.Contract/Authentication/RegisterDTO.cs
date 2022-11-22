using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Noa.PocketUi.Contract.Authentication
{
    public class RegisterDTO
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("mail")]
        public string Email { get; set; }
    }
}
