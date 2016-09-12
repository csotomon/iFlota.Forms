using Newtonsoft.Json;

namespace iFlota.Forms
{
	public class IdentidadClaim
	{
		[JsonProperty(PropertyName = "typ")]
		public string Typ { get; set; }
		[JsonProperty(PropertyName = "val")]
		public string Val { get; set; }
	}
}

