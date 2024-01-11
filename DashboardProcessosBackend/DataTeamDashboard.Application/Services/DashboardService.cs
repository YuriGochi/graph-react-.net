using AutoMapper;
using DataTeamDashboard.Application.Interfaces;
using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Dashboard.Response;
using DataTeamDashboard.Domain.Dto.Processes.Response;
using DataTeamDashboard.Domain.Entities;
using DataTeamDashboard.Domain.Interfaces;
using DataTeamDashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IProcessesRepository _processesRepository;
        private readonly IMapper _mapper;

        public DashboardService(IDashboardRepository dashboardRepository, IProcessesRepository processesRepository,IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _processesRepository = processesRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateDashboard(DashboardRegisterRequest request)
        {
            var req = _mapper.Map<Dashboard>(request);
            req.LastStatus = request.LastStatus;
            req.LastExecution = request.LastExecution;
            req.NextExecution = request.NextExecution;
            req.LogUrl = request.LogUrl;
            req.ProcessId = request.ProcessId;
            var dashboard = await _dashboardRepository.Add(req);
            return true;
        }

        public async Task<IList<DashboardResponse>> ListDashboard()
        {
            var dashboards = await _dashboardRepository.ListDashboard();

            var distinctProcessIds = dashboards.Select(d => d.ProcessId).Distinct();

            var processes = await _processesRepository.ListProcesses();

            var response = new List<DashboardResponse>();

            foreach (var processId in distinctProcessIds)
            {
                var associatedProcess = processes.FirstOrDefault(p => p.Id == processId);

                if (associatedProcess != null)
                {
                    var dashboardsForProcess = dashboards.Where(d => d.ProcessId == processId).ToList();
                    var dashboardResponsesForProcess = dashboardsForProcess.Select(d =>
                    {
                        var dashboardResponse = _mapper.Map<DashboardResponse>(d);
                        dashboardResponse.Process = _mapper.Map<ProcessesResponse>(associatedProcess);
                        return dashboardResponse;
                    }).ToList();

                    response.AddRange(dashboardResponsesForProcess);
                }
            }

            return response;
        }
        
    }
}
