namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController: ControllerBase
{
    public ProductController(
        ProductContext context,
        IAzureClientFactory<ServiceBusClient> serviceBusClientFactory,
        ILogger<ProductController> logger)
    {
        _context = context;
        _client = serviceBusClientFactory.CreateClient("ProductMessage");
        _logger = logger;
    } 

    [HttpPost]
    public async Task<ActionResult<TravelProduct>> PostProduct(TravelProduct product)
    {
        if (_context.TravelProducts == null)
        {
            return Problem("Entity set 'ProductContext.TravelProducts' is null.");
        }
        _context.TravelProducts.Add(product);
        await _context.SaveChangesAsync();

        try
        {
            var sender = _client.CreateSender("swsproducttoswspricing");
            var envelope = new 
            {
                To = "Pricing",
                From = "Product",
                Subject = "Create",
                Body = product
            };

            var message = new ServiceBusMessage(JsonSerializer.Serialize(envelope));
            await sender.SendMessageAsync(message);
        }
        catch(Exception ex)
        {
            _logger.LogWarning($"Unexpected integration failure; ${ex.Message}");
        }
        
        return CreatedAtAction("GetProduct", new { id = product.TravelProductId }, product);
    }    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TravelProduct>>> GetProducts()
    {
        if (_context.TravelProducts == null)
        {
            return NotFound();
        }

        return await _context.TravelProducts
            .Include(c => c.FacilityIdGoingToNavigation)
            .Include(c => c.FacilityIdOriginatingFrom)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TravelProduct>> GetProduct(int id)
    {
        var product = await _context.TravelProducts.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, TravelProduct product)
    {
        if (id != product.TravelProductId)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
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

        try
        {
            var sender = _client.CreateSender("swsproducttoswspricing");
            var envelope = new 
            {
                To = "Pricing",
                From = "Product",
                Subject = "Update",
                Body = product
            };

            var message = new ServiceBusMessage(JsonSerializer.Serialize(envelope));
            await sender.SendMessageAsync(message);
        }
        catch(Exception ex)
        {
            _logger.LogWarning($"Unexpected integration failure; ${ex.Message}");
        }        

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (_context.TravelProducts == null)
        {
            return NotFound();
        }

        var product = await _context.TravelProducts.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.TravelProducts.Remove(product);
        await _context.SaveChangesAsync();

        try
        {
            var sender = _client.CreateSender("swsproducttoswspricing");
            var envelope = new 
            {
                To = "Pricing",
                From = "Product",
                Subject = "Delete",
                Body = product
            };

            var message = new ServiceBusMessage(JsonSerializer.Serialize(envelope));
            await sender.SendMessageAsync(message);
        }
        catch(Exception ex)
        {
            _logger.LogWarning($"Unexpected integration failure; ${ex.Message}");
        }        

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return (_context.TravelProducts?.Any(p => p.TravelProductId == id)).GetValueOrDefault();
    }

    private readonly ProductContext _context;
    private readonly ServiceBusClient _client;
    private readonly ILogger<ProductController> _logger;      
}