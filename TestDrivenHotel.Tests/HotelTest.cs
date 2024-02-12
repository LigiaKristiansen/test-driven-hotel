using System;
using Xunit;
using TestDrivenHotel.BLL;
using FluentAssertions;

namespace TestDrivenHotel.Tests
{
    public class HotelTest
    {
        [Fact]
        public void GetAvailableRooms_ReturnsAvailableRooms()
        {
            // Given
            var repository = new HotelRepository();
            var checkInDate = DateTime.Now.AddDays(1);
            var checkOutDate = DateTime.Now.AddDays(3);
            var roomType = "Single";

            // When
            var availableRooms = repository.GetAvailableRooms(checkInDate, checkOutDate, roomType);

            // Then
            availableRooms.Should().NotBeNull();
            availableRooms.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void BookRoom_SuccessfullyBooksRoom()
        {
            // Given
            var repository = new HotelRepository();
            var booking = new Booking("John Doe", 1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));

            // When
            var result = repository.BookRoom(booking);

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void BookRoom_UnavailableRoom_ReturnsFalse()
        {
            // Given
            var repository = new HotelRepository();
            var booking = new Booking("John Doe", 1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));

            // When
           
            repository.BookRoom(booking);
            // Attempt to book the same room again
            var result = repository.BookRoom(booking);

            // Then
            result.Should().BeFalse();
        }
    }
}
