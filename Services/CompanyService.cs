using HubSpot_Integrations.Models;
using HubSpot_Integrations.Repositories;
using RestSharp;

namespace HubSpot_Integrations.Services
{
	// Service class implementing ICompanyRepository to interact with HubSpot API for company operations.
	public class CompanyService : ICompanyRepository
	{
		private readonly HubSpotService _hubSpotService;

		public CompanyService(HubSpotService hubSpotService)
		{
			_hubSpotService = hubSpotService;
		}

		// Asynchronously creates a new company in HubSpot
		public async Task<string> CreateCompany(Company company)
		{
			var request = new RestRequest("/crm/v3/objects/companies", Method.Post);
			request.AddHeader("Authorization", $"Bearer {_hubSpotService.Token}");
			request.AddJsonBody(new
			{
				properties = new
				{
					name = company.Name,
					domain = company.Domain,
					type = company.Type
				}
			});

			var response = await _hubSpotService.Client.ExecuteAsync(request);
			return _hubSpotService.HandleResponse(response);
		}

		// Asynchronously searches for a company by its ID in HubSpot
		public async Task<string> SearchCompany(string id)
		{
			var request = new RestRequest($"/crm/v3/objects/companies/{id}", Method.Get);
			request.AddHeader("Authorization", $"Bearer {_hubSpotService.Token}");

			var response = await _hubSpotService.Client.ExecuteAsync(request);
			return _hubSpotService.HandleResponse(response);
		}
	}
}