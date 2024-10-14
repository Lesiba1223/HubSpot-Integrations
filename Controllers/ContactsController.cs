using HubSpot_Integrations.Models;
using HubSpot_Integrations.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HubSpot_Integrations.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactsRepository _contactRepository;

		public ContactsController(IContactsRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		// POST: Creates a new contact
		[HttpPost]
		public async Task<IActionResult> CreateCompany([FromBody] Contacts contacts)
		{
			if (contacts == null || string.IsNullOrEmpty(contacts.Email) || string.IsNullOrEmpty(contacts.LifeCycleStage))
			{
				return BadRequest("Invalid contact data.");
			}

			try
			{
				var result = await _contactRepository.CreateContact(contacts);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = ex.Message });
			}
		}
	}
}