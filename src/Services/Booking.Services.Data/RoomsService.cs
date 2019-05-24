namespace Booking.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Rooms;

    public class RoomsService : IRoomsService
    {
        private readonly IRepository<Room> roomsRepository;

        public RoomsService(IRepository<Room> roomsRepository)
        {
            this.roomsRepository = roomsRepository;
        }

        public RoomViewModel GetRoomByRoomId(int id)
        {
            return this.GetRoomById(id).To<RoomViewModel>().FirstOrDefault();
        }

        public async Task CreateRoomAsync(int hotelId, CreateRoomBindingModel bindingModel)
        {
            var room = Mapper.Map<Room>(bindingModel);
            await this.roomsRepository.AddAsync(room);
            await this.roomsRepository.SaveChangesAsync();
        }

        public RoomPeriodsViewModel GetRoomPeriods(int id)
        {
            return this.GetRoomById(id).To<RoomPeriodsViewModel>().FirstOrDefault();
        }

        public IEnumerable<RoomAdminViewModel> GetAllRooms()
        {
            return this.GetRoomsInfo().To<RoomAdminViewModel>().ToList();
        }

        public EditRoomViewModel GetEditRoom(int id)
        {
            return this.GetRoomById(id).To<EditRoomViewModel>().FirstOrDefault();
        }

        public async Task EditRoom(int id, EditRoomBindingModel bindingModel)
        {
            Room editRoom = this.GetRoomById(id).FirstOrDefault();
            editRoom.Name = bindingModel.Name;

            await this.roomsRepository.SaveChangesAsync();
        }

        public RoomAdminDetailsViewModel GetRoomDetails(int id)
        {
            return this.GetRoomById(id).To<RoomAdminDetailsViewModel>().FirstOrDefault();
        }

        private IQueryable<Room> GetRoomById(int id)
        {
            return this.GetRoomsInfo(r => r.Id == id);
        }

        private IQueryable<Room> GetRoomsInfo(
            Expression<Func<Room, bool>> predicate = null,
            Expression<Func<Room, object>> orderBySelector = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Room> roomsQuery = this.roomsRepository.All();
            if (predicate != null)
            {
                roomsQuery = roomsQuery.Where(predicate);
            }

            if (orderBySelector != null)
            {
                roomsQuery = roomsQuery.OrderBy(orderBySelector);
            }

            if (skip != null)
            {
                roomsQuery = roomsQuery.Skip(skip.Value);
            }

            if (take != null)
            {
                roomsQuery = roomsQuery.Take(take.Value);
            }

            return roomsQuery;
        }
    }
}
