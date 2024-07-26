using E_CommerceApi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {
        private readonly IFeedBackReadRepository _feedBackReadRepository;
        private readonly IFeedBackWriteRepository _feedBackWriteRepository;

        public FeedBacksController(IFeedBackReadRepository feedBackReadRepository, IFeedBackWriteRepository feedBackWriteRepository)
        {
            _feedBackReadRepository = feedBackReadRepository;
            _feedBackWriteRepository = feedBackWriteRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _feedBackReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {

        }
        
    }
}
