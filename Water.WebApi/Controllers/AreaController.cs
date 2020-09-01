using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Water.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase
    {

        private readonly Domain.AreaController controller;

        public AreaController(Domain.AreaController controller)
        {
            this.controller = controller;
        }

        // curl -d '"aaa"' -H "Content-Type: application/json" --insecure -X POST https://localhost:5001/Area/Add
        [HttpPost]
        [Route("Add")]
        public async Task AddAsync([FromBody] string name)
        {
            await controller.AddAsync(name);
        }

        // curl --insecure -X GET https://localhost:5001/Area/All
        [HttpGet]
        [Route("All")]
        public async Task<string[]> AllAsync()
        {
            var array = await controller.AllAsync();
            return array;
        }

        // curl --insecure -X POST https://localhost:5001/Area/Post
        [HttpGet]
        [Route("Pong")]
        public string Get()
        {
            return "pong";
        }

        // curl -d '"aaa"' -H "Content-Type: application/json" --insecure -X POST https://localhost:5001/Area/Post
        [HttpPost]
        [Route("Post")]
        public string Post([FromBody] string name)
        {
            return name;
        }

    }
}
