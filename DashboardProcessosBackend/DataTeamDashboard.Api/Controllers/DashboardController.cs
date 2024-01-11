using DataTeamDashboard.Application.Interfaces;
using DataTeamDashboard.Application.Services;
using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Process.Request;
using Microsoft.AspNetCore.Mvc;

namespace DataTeamDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _DashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _DashboardService = dashboardService;
        }

        [HttpGet]
        [Route("ListDashboard")]
        public async Task<ActionResult> ListDashboard()
        {
            var result = await _DashboardService.ListDashboard();
            return Ok(result);
        }

        [HttpPost]
        [Route("createDashboard")]
        public async Task<ActionResult> CreateDashboard([FromBody] DashboardRegisterRequest request)
        {
            var response = await _DashboardService.CreateDashboard(request);
            return Ok(response);
        }
    }
}
