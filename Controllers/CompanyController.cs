using HubSpot_Integrations.Models;
using HubSpot_Integrations.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HubSpot_Integrations.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyController(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		// POST: Creates a new company
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Company company)
		{
			if (company == null || string.IsNullOrEmpty(company.Name) || string.IsNullOrEmpty(company.Domain))
			{
				return BadRequest("Invalid company data.");
			}

			try
			{
				var result = await _companyRepository.CreateCompany(company);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = ex.Message });
			}
		}

		// GET: Retrieves a company by its ID
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCompany(string id)
		{
			try
			{
				var result = await _companyRepository.SearchCompany(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound($"Company with ID {id} not found: {ex.Message}");
			}
		}
	}
}