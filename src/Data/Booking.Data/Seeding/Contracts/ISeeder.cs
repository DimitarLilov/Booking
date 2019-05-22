namespace Booking.Data.Seeding.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(BookingDbContext dbContext, IServiceProvider serviceProvider);
    }
}