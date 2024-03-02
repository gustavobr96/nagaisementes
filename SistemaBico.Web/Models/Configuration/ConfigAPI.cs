namespace SistemaBico.Web.Models.Configuration
{
   public class ConfigAPI
    {
        public string UrlAPI { get; set; }

        public ConfigAPI()
        {
            // LocalHost
            UrlAPI = "https://localhost:5001/v1/api/";

        }
    }
}
