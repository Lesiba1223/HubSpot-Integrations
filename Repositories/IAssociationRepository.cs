namespace HubSpot_Integrations.Repositories
{
	public interface IAssociationRepository
	{
		//The interface for Association repository, defining methods for creating an association.
		Task<string> CreateAssociation(string fromId, string toId, string type);
	}
}
