using E_CommerceApi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
           await _productWriteRepository.AddRangeAsync(new()
            {

                new () {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name= "Product1", Stock = 10, Price=100},
                new () {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name= "Product2", Stock = 10, Price=200},
                new () {Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name= "Product3", Stock = 10, Price=300}
            });

            await _productWriteRepository.SaveAsync();
        }
    }
}
