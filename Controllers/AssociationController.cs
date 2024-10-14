using HubSpot_Integrations.Models;
using HubSpot_Integrations.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssociationController : ControllerBase
	{
		private readonly IAssociationRepository _associationRepository;
		public AssociationController(IAssociationRepository associationRepository)
		{
			_associationRepository = associationRepository;
		}

		// POST: Creates a new association
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Association association)
		{
			if (association == null || string.IsNullOrEmpty(association.ContactID) || string.IsNullOrEmpty(association.CompanyID))
			{
				return BadRequest("Valid Contact ID and Company ID are required.");
			}

			try
			{
				var result = await _associationRepository.CreateAssociation(association.ContactID, association.CompanyID, association.Type);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = ex.Message });
			}
		}
	}
}
