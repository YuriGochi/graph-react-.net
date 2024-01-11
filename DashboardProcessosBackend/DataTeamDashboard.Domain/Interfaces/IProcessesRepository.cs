using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Dto.Processes.Response;
using DataTeamDashboard.Domain.Entities;
using DataTeamDashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Domain.Interfaces
{
    public interface IProcessesRepository : IRepository<Process>
    {
        Task<IList<ProcessesResponse>> ListProcesses();
        Task<bool>CreateProcess(ProcessRegisterRequest request);
    }
}
