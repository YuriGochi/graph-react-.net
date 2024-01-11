using AutoMapper;
using DataTeamDashboard.Domain.Dto.Process.Request;
using DataTeamDashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Application.Mapper
{
    public class ProcessProfile : Profile
    {

        public ProcessProfile()
        {
            CreateMap<Process, ProcessRegisterRequest>().ReverseMap();
        }
    }
}
