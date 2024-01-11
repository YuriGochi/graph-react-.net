using AutoMapper;
using DataTeamDashboard.Application.Interfaces;
using DataTeamDashboard.Application.Models;
using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Dto.Processes.Response;
using DataTeamDashboard.Domain.Entities;
using DataTeamDashboard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Services
{
    public class ProcessesService : IProcessesService
    {
        private readonly IProcessesRepository _processesRepository;
        private readonly IMapper _mapper;

        public ProcessesService(IProcessesRepository processesRepository, IMapper mapper)
        {
            _processesRepository = processesRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProcessesResponse>> ListProcesses()
        {
            var processes = await _processesRepository.ListProcesses();

            return processes;
        }

        public async Task<bool> CreateProcess(ProcessRegisterRequest request)
        {
            var req = _mapper.Map<Process>(request);
            req.Name = request.Name;
            req.Description = request.Description;
            var process = await _processesRepository.Add(req);
            return true;
        }
    }
}
