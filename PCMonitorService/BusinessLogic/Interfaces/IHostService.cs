using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace BusinessLogic.Interfaces
{
    public interface IHostService
    {
        Task<IEnumerable<Host>> ListAsync();
    }
}
