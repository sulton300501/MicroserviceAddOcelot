using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTO;
using ProductService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
          

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _context.Products.ToListAsync();
            return Ok(result);
        }





    }
}
