using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AuctionService.Entities;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AuctionDbContext>();
        SeedData(context);
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Database already seeded. Skipping seeding process.");
            return;
        }

        var auctions = new List<Auction>()
        {
            new Auction
            {
                Id = Guid.NewGuid(),
                ReservePrice = 1000,
                Seller = "John Doe",
                Winner = null,
                SoldAmount = null,
                CurrentHighestBid = null,
                CreatedAt = DateTime.UtcNow,
                EndedAt = null,
                AuctionEnd = DateTime.UtcNow.AddDays(7),
                Status = Status.Live,
                Item = new Item
                {
                    Id = Guid.NewGuid(),
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    Color = "Blue",
                    Mileage = 15000,
                    ImageUrl = "https://example.com/toyota_camry.jpg"
                }
            },
            new Auction
            {
                Id = Guid.NewGuid(),
                ReservePrice = 5000,
                Seller = "Jane Smith",
                Winner = null,
                SoldAmount = null,
                CurrentHighestBid = null,
                CreatedAt = DateTime.UtcNow,
                EndedAt = null,
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Status = Status.Live,
                Item = new Item
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2019,
                    Color = "Red",
                    Mileage = 20000,
                    ImageUrl = "https://example.com/honda_civic.jpg"
                }
            }
        };

        context.AddRange(auctions);
        context.SaveChanges();
    }
}