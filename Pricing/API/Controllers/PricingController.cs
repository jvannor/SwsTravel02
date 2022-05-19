namespace PricingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PricingController : ControllerBase
{
    public PricingController(
        PricingContext context,
        ILogger<PricingController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<PriceComponent>> PostPriceComponent(PriceComponent component)
    {
        if (_context.PriceComponents == null)
        {
            return Problem("Entity set 'PricingContext.PriceComponents' is null.");
        }
        _context.PriceComponents.Add(component);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPriceComponent", new { id = component.PriceComponentId }, component);
    }  

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PriceComponent>>> GetPriceComponents()
    {
        if (_context.PriceComponents == null)
        {
            return NotFound();
        }

        return await _context.PriceComponents.ToListAsync();
    }      

    [HttpGet("{id}")]   
    public async Task<ActionResult<PriceComponent>> GetPriceComponent(int id)
    {
        var component = await _context.PriceComponents.FindAsync(id);
        if (component == null)
        {
            return NotFound();
        }

        return component;
    }  

    [HttpPut("{id}")]   
    public async Task<IActionResult> PutPriceComponent(int id, PriceComponent component)
    {
        if (id != component.PriceComponentId)
        {
            return BadRequest();
        }

        _context.Entry(component).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (!PriceComponentExists(id))
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

    [HttpDelete]
    public async Task<IActionResult> DeletePriceComponent(int id)
    {
        if (_context.PriceComponents == null)
        {
            return NotFound();
        }

        var component = await _context.PriceComponents.FindAsync(id);
        if (component == null)
        {
            return NotFound();
        }

        _context.PriceComponents.Remove(component);
        await  _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PriceComponentExists(int id)
    {
        return (_context.PriceComponents?.Any(pc => pc.PriceComponentId == id)).GetValueOrDefault();
    }

    private readonly PricingContext _context;
    private readonly ILogger<PricingController> _logger;
}