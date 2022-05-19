namespace ProductToPricing.Models;

public class Envelope
{
    public string To { get; set; }

    public string From { get; set; }

    public string Subject { get; set; }

    public TravelProduct Body { get; set; }
}