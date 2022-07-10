using GeekShopping.ProductAPI.Data.DTOs;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRespository _repository;

        public ProductController(IProductRespository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _repository.FindAll();            
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Create(productDTO);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Update(productDTO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status)
                return BadRequest();
            
            return Ok(status);
        }
    }
}
