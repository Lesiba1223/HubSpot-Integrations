using HubSpot_Integrations.Models;

namespace HubSpot_Integrations.Repositories
{
	//The interface for Contact repository, defining method for creating contact.
	public interface IContactsRepository
	{
		Task<string> CreateContact(Contacts contacts);
	}
}
