namespace Booking.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Booking.Data.Seeding.Contracts;

    internal class RoomsSeeder : ISeeder
    {
        public async Task SeedAsync(BookingDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Rooms.Any())
            {
                return;
            }

            await dbContext.Rooms.AddRangeAsync();
        }
    }
}
