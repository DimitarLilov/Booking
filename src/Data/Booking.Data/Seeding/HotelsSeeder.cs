namespace Booking.Data.Seeding
{
    using System;
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
                Floors = 5
            };

            await dbContext.Hotels.AddAsync(HotelHebar);
        }
    }
}
