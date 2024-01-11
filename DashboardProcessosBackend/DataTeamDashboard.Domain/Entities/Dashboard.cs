using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Domain.Entities
{
    public class Dashboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public virtual int Id { get; set; }
        [Column("LastExecution")]
        public virtual DateTime LastExecution { get; set; }
        [Column("NextExecution")]
        public virtual DateTime NextExecution { get; set; }
        [Column("LogUrl")]
        public virtual string? LogUrl { get; set; }
        [Column("LastStatus")]
        public virtual string? LastStatus { get; set; }
        public virtual int ProcessId { get; set; }
    }
}
