using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace DataAccess.Repository
{
    public class HostRepository : BaseRepository, IHostRepository
    {
        public HostRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Host>> ListAsync()
        {
            return await _context.Hosts.ToListAsync();
        }
    }
}
