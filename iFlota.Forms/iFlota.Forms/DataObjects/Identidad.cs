using Newtonsoft.Json;
using System.Collections.Generic;


namespace iFlota.Forms.DataObjects
{
    public class Identidad
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "expires_on")]
        public string ExpiresOn { get; set; }
        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }
        [JsonProperty(PropertyName = "user_claims")]
        public List<IdentidadClaim> UserClaims { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
    }

    public class IdentidadClaim
    {
        [JsonProperty(PropertyName = "typ")]
        public string Typ { get; set; }
        [JsonProperty(PropertyName = "val")]
        public string Val { get; set; }
    }
}
