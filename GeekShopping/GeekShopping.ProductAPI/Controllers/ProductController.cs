using GeekShopping.ProductAPI.Domain.IRepository;
using GeekShopping.ProductAPI.Domain.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository; 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var product = await _repository.FindById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductVM vm)
        {
            if (vm == null) return BadRequest();
            var product = await _repository.Create(vm);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductVM vm)
        {
            if (vm == null) return BadRequest();
            var product = await _repository.Update(vm);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
