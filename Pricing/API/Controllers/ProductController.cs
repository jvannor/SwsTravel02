namespace PricingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public ProductController(
        PricingContext context,
        ILogger<ProductController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<PriceComponent>> PostProduct(Product product)
    {
        if (_context.Products == null)
        {
            return Problem("Entity set 'PricingContext.Products' is null.");
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
    }     

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        if (_context.Products == null)
        {
            return NotFound();
        }

        return await _context.Products.ToListAsync();
    } 

    [HttpGet("{id}")]   
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }  

    [HttpPut("{id}")]   
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await  _context.SaveChangesAsync();

        return NoContent();
    }    

    private bool ProductExists(int id)
    {
        return (_context.Products?.Any(p => p.ProductId == id)).GetValueOrDefault();
    }

    private readonly PricingContext _context;
    private readonly ILogger<ProductController> _logger;
}