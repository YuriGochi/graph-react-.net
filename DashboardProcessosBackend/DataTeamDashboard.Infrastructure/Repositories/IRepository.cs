using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeamDashboard.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(decimal id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(decimal id);
    }
}
