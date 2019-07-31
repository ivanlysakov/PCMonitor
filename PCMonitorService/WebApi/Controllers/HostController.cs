using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    public class HostController : Controller
    {
        private readonly IHostService _hostService;
        public HostController(IHostService hostService)
        {
            _hostService = hostService;
        }

        [HttpGet]
        public async Task<IEnumerable<Host>> GetAllAsync()
        {
            var hosts = await _hostService.ListAsync();
            return hosts;
        }




    }
}
