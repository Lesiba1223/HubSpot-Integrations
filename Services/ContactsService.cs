using HubSpot_Integrations.Models;
using HubSpot_Integrations.Repositories;
using RestSharp;

namespace HubSpot_Integrations.Services
{
	// Service class implementing IContactsRepository to interact with HubSpot API for contacts operations.
	public class ContactsService : IContactsRepository
	{
		private readonly HubSpotService _hubSpotService;

		public ContactsService(HubSpotService hubSpotService)
		{
			_hubSpotService = hubSpotService;
		}

		// Asynchronously creates a new contact in HubSpot
		public async Task<string> CreateContact(Contacts contacts)
		{
			var request = new RestRequest("crm/v3/objects/contacts", Method.Post);
			request.AddHeader("Authorization", $"Bearer {_hubSpotService.Token}");
			request.AddJsonBody(new
			{
				properties = new
				{
					email = contacts.Email,
					firstname = contacts.FirstName,
					phone = contacts.Phone,
					lastname = contacts.LastName,
					lifecyclestage = contacts.LifeCycleStage
				}
			});

			var response = await _hubSpotService.Client.ExecuteAsync(request);
			return _hubSpotService.HandleResponse(response);
		}
	}
}