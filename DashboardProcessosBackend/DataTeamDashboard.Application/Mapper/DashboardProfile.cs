using AutoMapper;
using DataTeamDashboard.Domain.Dto.Dashboard.Request;
using DataTeamDashboard.Domain.Dto.Dashboard.Response;
using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Mapper
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<Dashboard, DashboardRegisterRequest>().ReverseMap();
            CreateMap<Dashboard, DashboardResponse>().ReverseMap();
        }
    }
}
