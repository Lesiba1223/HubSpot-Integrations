using HubSpot_Integrations.Repositories;
using RestSharp;

namespace HubSpot_Integrations.Services
{
	// Service class implementing IAssociationRepository to interact with HubSpot API for association operations.
	public class AssociationService : IAssociationRepository
	{
		private readonly HubSpotService _hubSpotService;

		public AssociationService(HubSpotService hubSpotService)
		{
			_hubSpotService = hubSpotService;
		}

		// Asynchronously creates an association in HubSpot
		public async Task<string> CreateAssociation(string fromId, string toId, string type)
		{
			var request = new RestRequest("crm/v3/associations/Contacts/Companies/batch/create", Method.Post);
			request.AddHeader("Authorization", $"Bearer {_hubSpotService.Token}");
			request.AddJsonBody(new
			{
				inputs = new[]
				{
					new
					{
						from = new { id = fromId },
						to = new { id =  toId },
						 type
					}
				}
			});

			var response = await _hubSpotService.Client.ExecuteAsync(request);
			return _hubSpotService.HandleResponse(response);
		}
	}
}