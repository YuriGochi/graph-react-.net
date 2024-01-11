using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Dashboard.Response;
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
    public interface IDashboardRepository : IRepository<Dashboard>
    {
        Task<IList<Dashboard>> ListDashboard();
        Task<bool>CreateDashboard(DashboardRegisterRequest request);
    }
}
