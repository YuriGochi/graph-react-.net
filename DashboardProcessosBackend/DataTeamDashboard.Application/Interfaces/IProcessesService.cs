using DataTeamDashboard.Application.Models;
using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Dto.Processes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Interfaces
{
    public interface IProcessesService
    {
        Task<IList<ProcessesResponse>> ListProcesses();
        Task<bool> CreateProcess(ProcessRegisterRequest request);
    }
}
