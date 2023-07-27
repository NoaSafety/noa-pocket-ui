using System.Text.Json.Serialization;

namespace Noa.PocketUi.Contract.Authentication
{
    public class UserData
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
