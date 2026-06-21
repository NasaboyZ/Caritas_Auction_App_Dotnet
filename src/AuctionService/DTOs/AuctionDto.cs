namespace AuctionService.DTos;

public class AuctionDto
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set; }

    public string Seller { get; set; }
    public string Winner { get; set; }
    public int SoldAmount { get; set; }
    public int CurrentHighestBid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EndedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; }


}