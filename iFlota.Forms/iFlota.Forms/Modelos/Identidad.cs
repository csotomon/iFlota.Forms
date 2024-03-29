﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace iFlota.Forms.Modelos
{
    /// <summary>
    /// Clase para el manejo de la identidad obtenida por OAuth y será convertida
    /// desde un objeton tipo Json.
    /// </summary>
	public class Identidad
	{
		[JsonProperty(PropertyName = "access_token")]
		public string AccessToken { get; set; }
		[JsonProperty(PropertyName = "expires_on")]
		public string ExpiresOn { get; set; }
		[JsonProperty(PropertyName = "provider_name")]
		public string ProviderName { get; set; }

        /// <summary>
        /// Lista de claims de la identidad
        /// </summary>
		[JsonProperty(PropertyName = "user_claims")]
		public List<IdentidadClaim> UserClaims { get; set; }
		[JsonProperty(PropertyName = "user_id")]
		public string UserId { get; set; }
	}
}

