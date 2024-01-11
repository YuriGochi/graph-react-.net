using DataTeamDashboard.Application.Interfaces;
using DataTeamDashboard.Domain.Dto.Process.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataTeamDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private readonly IProcessesService _ProcessesService;
        public ProcessesController(IProcessesService processesService)
        {
            _ProcessesService = processesService;
        }

        [HttpGet]
        [Route("ListProcesses")]
        public async Task<ActionResult> ListProcesses()
        {
            var result = await _ProcessesService.ListProcesses();
            return Ok(result);
        }

        [HttpPost]
        [Route("createProcesses")]
        public async Task<ActionResult> CreateProcess([FromBody] ProcessRegisterRequest request)
        {
            var response = await _ProcessesService.CreateProcess(request);
            return Ok(response);
        }
    }
}
