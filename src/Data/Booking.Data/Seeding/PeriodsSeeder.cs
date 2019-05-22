namespace Booking.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Booking.Data.Models;
    using Booking.Data.Seeding.Contracts;

    internal class PeriodsSeeder : ISeeder
    {
        public async Task SeedAsync(BookingDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Periods.Any())
            {
                return;
            }

            var perod = new Period()
            {
                Price = 10.20m,
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddDays(5),
                RoomId = dbContext.Rooms.FirstOrDefault().Id
            };

            await dbContext.Periods.AddAsync(perod);
        }
    }
}
