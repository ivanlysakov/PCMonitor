using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace BusinessLogic.Services
{
    public class HostService : IHostService
    {
                
        private readonly IHostRepository _hostRepository;

        public HostService(IHostRepository hostRepository)
        {
            this._hostRepository = hostRepository;
        }

        public async Task<IEnumerable<Host>> ListAsync()
        {
            return await _hostRepository.ListAsync();
        }
    
    }
}
