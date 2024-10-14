using HubSpot_Integrations.Models;

namespace HubSpot_Integrations.Repositories
{
	//The interface for Company repository, defining methods for creating and searching for company by id.
	public interface ICompanyRepository
	{
		Task<string> CreateCompany(Company company);
		Task<string> SearchCompany(string id);
	}
}
