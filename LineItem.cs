using System.Text.Json.Serialization;

namespace Axeptia.Function
{
    public class LineItem
    {
        [JsonPropertyName("Fornavn")]
        public string firstName {get;set;}
        [JsonPropertyName("Etternavn")]
        public string lastName {get;set;}
        [JsonPropertyName("Tittel")]
        public string title {get;set;}

        public LineItem()
        {

        }
        
    }
}