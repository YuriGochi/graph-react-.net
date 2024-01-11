using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Dashboard.Response;
using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Dto.Processes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<bool> CreateDashboard(DashboardRegisterRequest request);
        Task<IList<DashboardResponse>> ListDashboard(); 
    }
}
