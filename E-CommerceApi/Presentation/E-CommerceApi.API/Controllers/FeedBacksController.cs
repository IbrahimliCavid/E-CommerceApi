using E_CommerceApi.Application.Repositories;
using E_CommerceApi.Application.RequestParametrs;
using E_CommerceApi.Application.ViewModels.FeedBacks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount =await _feedBackReadRepository.GetAll(false).CountAsync();
            var feedBacks =  _feedBackReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(feedBack => new
            {
                feedBack.Id,
                feedBack.Name,
                feedBack.Surname,
                feedBack.Description

            }).ToList();


            return Ok(new
            {
                feedBacks,
                totalCount
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _feedBackReadRepository.GetByIdAsync(id, false));
        }
        [HttpPut]
        public async Task<IActionResult> Update(VMUpdateFeedBack model)
        {
            var feedBack = await _feedBackReadRepository.GetByIdAsync(model.Id);
            feedBack.Name = model.Name;
            feedBack.Surname = model.Surname;
            feedBack.Description = model.Description;

             _feedBackWriteRepository.Update(feedBack);
            await _feedBackWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(VMCreateFeedBack model)
        {
            await _feedBackWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Surname = model.Surname,
                Description = model.Description
            });

            await _feedBackWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _feedBackWriteRepository.Remove(id);
            await _feedBackWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
