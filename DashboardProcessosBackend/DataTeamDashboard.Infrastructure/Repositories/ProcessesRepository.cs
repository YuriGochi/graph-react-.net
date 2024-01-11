using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Dto.Processes.Response;
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
    public class ProcessesRepository: BaseRepository<Process, DataContext>, IProcessesRepository
    {
        private readonly DataContext databaseContext;
        
        public ProcessesRepository(DataContext _dbContext) : base(_dbContext)
        {
            this.databaseContext = _dbContext;
        }

        public Task<bool> CreateProcess(ProcessRegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProcessesResponse>> ListProcesses()
        {
            var processes = await GetAll();

            var result = processes.Select(p => new ProcessesResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToList();

            return result;
        }

    }
}
