using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entitis;

[Table("Items")] // This attribute is used to specify the name of the table in the database that this entity will be mapped to. In this case, it indicates that instances of the Item class will be stored in a table named "Items".
public class Item
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }
    public string ImageUrl { get; set; }

    // nav props
    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }


}
