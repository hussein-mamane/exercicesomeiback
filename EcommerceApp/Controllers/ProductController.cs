using EcommerceApp.Data;
using EcommerceApp.DTOs.Product;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers;
using EcommerceApp.Mappers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly MyDbContext _context;
    private readonly ILogger<ProductController> _logger;

    public ProductController(MyDbContext context, ILogger<ProductController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        IEnumerable<Product> products = await _context.Products.ToListAsync();//never null
        foreach (var product in products)
        {
            product.ToProductDto();
        }
        return Ok(products);
        // return NotFound();
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var products = await _context.Products.FindAsync(id);
        if (products != null) return Ok(products.ToProductDto());
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] RequestToProduct productDto)
    {
        var productModel = productDto.ToProductFromCreateDto();
        if (!ModelState.IsValid) return BadRequest();
        _context.Products.Add(productModel);
        await _context.SaveChangesAsync();
        _logger.Log(LogLevel.Information,$"Created Product at {DateTime.Now}");
        return CreatedAtAction(nameof(GetProductById), new { id = productModel.ProductId, },
            productModel.ToProductDto());
    }
}
