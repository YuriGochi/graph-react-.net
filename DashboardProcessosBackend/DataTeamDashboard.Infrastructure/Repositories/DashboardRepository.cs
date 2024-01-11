using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Dashboard.Response;
using DataTeamDashboard.Domain.Entities;
using DataTeamDashboard.Domain.Interfaces;
using DataTeamDashboard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using PortalSociedadesBackEnd.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Infrastructure.Repositories
{
    public class DashboardRepository : BaseRepository<Dashboard, DataContext>, IDashboardRepository
    {
        private readonly DataContext databaseContext;

        public DashboardRepository(DataContext _dbContext) : base(_dbContext)
        {
            this.databaseContext = _dbContext;
        }

        public Task<bool> CreateDashboard(DashboardRegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Dashboard>> ListDashboard()
        {
            var response = await databaseContext.Dashboard.ToListAsync();

            return response;
        }
    }
}
