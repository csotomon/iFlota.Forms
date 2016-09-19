using Newtonsoft.Json;

namespace iFlota.Forms
{
    /// <summary>
    /// Clase de representa un claim de tipo OAuth y se convertidad desde
    /// un objeto Json.
    /// </summary>
	public class IdentidadClaim
	{
		[JsonProperty(PropertyName = "typ")]
		public string Typ { get; set; }
		[JsonProperty(PropertyName = "val")]
		public string Val { get; set; }
	}
}

