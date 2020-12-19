using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private SearchService _searchService;
        public SearchController(RoofCareDbContext dbContext)
        {
            _searchService = new SearchService(dbContext);
        }
        [HttpGet]
        public IActionResult Get(string searchItem)
        {
            return Ok(_searchService.SearchItem(searchItem));
        }
    }
}
