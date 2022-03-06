using BL.Services;
using DB.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Exceptions;

namespace VisionHealthCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Create));
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.Get(id);
                if (product is null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Create));
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery(Name = "name")] string name)
        {
            try
            {
                return Ok(await _productService.SearchByName(name));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Create));
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                await _productService.Add(product);
                return Created(product.ProductId.ToString(), product.ProductId.ToString());
            }
            catch (InvalidProductException ex)
            {
                _logger.LogError(ex, "Invalid product on {0}", nameof(Create));
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Create));
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] IEnumerable<Product> products)
        {
            try
            {
                await _productService.Add(products);
                return Ok();
            }
            catch (InvalidProductException ex)
            {
                _logger.LogError(ex, "Invalid product on {0}", nameof(Import));
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Import));
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Product product, Guid id)
        {
            try
            {
                product.ProductId = id;
                await _productService.Update(product);
                return Ok();
            }
            catch (InvalidProductException ex)
            {
                _logger.LogError(ex, "Invalid product on {0}", nameof(Update));
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Update));
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.Delete(id);
                return Ok();
            }
            catch (InvalidProductException ex)
            {
                _logger.LogError(ex, "Invalid product on {0}", nameof(Delete));
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on {0}", nameof(Delete));
                return BadRequest(ex.Message);
            }
        }
    }
}
