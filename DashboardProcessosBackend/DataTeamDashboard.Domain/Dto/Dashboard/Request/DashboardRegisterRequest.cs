using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Domain.Dto.Dashboard.Request
{
    public class DashboardRegisterRequest
    {
        public DateTime LastExecution { get; set; }
        public DateTime NextExecution { get; set; }
        public string LogUrl { get; set; }
        public string LastStatus { get; set; }
        public int ProcessId { get; set; }
    }
}
