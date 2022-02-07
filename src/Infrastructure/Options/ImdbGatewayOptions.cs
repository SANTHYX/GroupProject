namespace Infrastructure.Options
{
    public class ImdbGatewayOptions
    {
        public const string Section = "ExternalServices:Imdb";
        public string Url { get; set;}
        public string ApiKey { get; set; }
    }
}
