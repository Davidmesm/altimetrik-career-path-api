using CareerPathCore.API.DTOs.Auth;
using CareerPathCore.Application.Services.AuthService;
using CareerPathCore.Application.Services.CatalogService;
using CareerPathCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CareerPathCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService)
        {
            _catalogService = catalogService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet()]
        public async Task<IEnumerable<EducationLevel>> GetEducationLevelList()
        {
            return await _catalogService.GetEducationLevels();
        }
    }
}
