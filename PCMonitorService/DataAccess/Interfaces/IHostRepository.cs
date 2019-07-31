using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace DataAccess.Interfaces
{
    public interface IHostRepository
    {
        Task<IEnumerable<Host>> ListAsync();
    }
}
