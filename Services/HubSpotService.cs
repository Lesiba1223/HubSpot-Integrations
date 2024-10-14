using RestSharp;

namespace HubSpot_Integrations.Services
{
	public class HubSpotService
	{
		public string Token { get; }
		public RestClient Client { get; }

		public HubSpotService(string token)
		{
			Token = token;
			Client = new RestClient("https://api.hubapi.com");
		}

		//Method for handling HubSpot API responses
		public string HandleResponse(RestResponse response)
		{
			if (response.IsSuccessful)
			{
				return response.Content;
			}
			return $"Error: {response.StatusCode} - {response.Content}";
		}
	}
}