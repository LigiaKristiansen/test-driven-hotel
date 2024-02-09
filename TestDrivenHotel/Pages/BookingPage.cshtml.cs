using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using TestDrivenHotel.BLL;
using TestDrivenHotel.DAL;

namespace TestDrivenHotel.Pages
{
    public class BookingPageModel : PageModel
    {
        private readonly HotelRepository _repository;

        [BindProperty]
        public Booking Booking { get; set; }

        public List<RoomModel> AvailableRooms { get; set; }

        public BookingPageModel()
        {
            _repository = new HotelRepository(); // Initialize the repository
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Attempt to book the room
            if (_repository.BookRoom(Booking))
            {
                return RedirectToPage("/ConfirmationPage"); // Redirect to confirmation page on successful booking
            }
            else
            {
                TempData["ErrorMessage"] = "Room is not available for the selected dates."; // Display error message if room is not available
                return Page();
            }
        }

        public IActionResult OnPostSearch()
        {
            // Get available rooms based on the search criteria
            AvailableRooms = _repository.GetAvailableRooms(Booking.CheckInDate, Booking.CheckOutDate);
            return Page();
        }
    }
}
