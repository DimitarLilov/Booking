namespace Booking.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Booking.Data.Models;
    using Booking.Data.Seeding.Contracts;

    internal class HotelsSeeder : ISeeder
    {
        public async Task SeedAsync(BookingDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Hotels.Any())
            {
                return;
            }

            var HotelHebar = new Hotel
            {
                Name = "Hebar",
                Floors = 5,
                Rooms = new List<Room>
                {
                     new Room()
                    {
                        Name = "100",
                        Floor = 1
                    },
                    new Room()
                    {
                        Name = "101",
                        Floor = 1
                    },
                    new Room()
                    {
                        Name = "102",
                        Floor = 1
                    },
                    new Room()
                    {
                        Name = "103",
                        Floor = 1
                    },
                    new Room()
                    {
                        Name = "104",
                        Floor = 1
                    },
                    new Room()
                    {
                        Name = "105",
                        Floor = 1
                    },
                     new Room()
                    {
                        Name = "200",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "201",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "202",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "203",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "204",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "205",
                        Floor = 2
                    },
                    new Room()
                    {
                        Name = "300",
                        Floor = 3
                    },
                    new Room()
                    {
                        Name = "400",
                        Floor = 4
                    },
                    new Room()
                    {
                        Name = "500",
                        Floor = 5
                    }
                }
            };

            await dbContext.Hotels.AddAsync(HotelHebar);
        }
    }
}
