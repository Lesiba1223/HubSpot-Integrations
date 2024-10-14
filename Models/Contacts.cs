namespace HubSpot_Integrations.Models
{
	public class Contacts
	{
		public required string Email { get; set; }
		public required string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public required string LifeCycleStage { get; set; }
	}
}
