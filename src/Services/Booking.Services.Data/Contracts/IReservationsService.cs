﻿namespace Booking.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Booking.Web.Models.Reservations;

    public interface IReservationsService
    {
        IEnumerable<ReservationDetailsViewModel> GetReservationsByRoomId(int id);

        IEnumerable<ReservaionDateViewModel> GetReservationsByRoomIdFilterByMonthAndYear(int id, int month, int year);

        bool RoomIsReserved(int id, DateTime date);

        Task ReservationRoom(ReservationRoomBindingModel bindingModel, string userId);

        IEnumerable<ReservationDetailsViewModel> GetReservationsDetailsByPeriodsAndRoomId(DateTime start, DateTime end, int roomId);

        IEnumerable<ReservationDetailsViewModel> GetAllReservation();
    }
}
