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
            _repository = new HotelRepository(); 
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

            
            if (_repository.BookRoom(Booking))
            {
                return RedirectToPage("/ConfirmationPage"); 
            }
            else
            {
                TempData["ErrorMessage"] = "Room is not available for the selected dates."; 
                return Page();
            }
        }

        public IActionResult OnPostSearch()
        {            
            AvailableRooms = _repository.GetAvailableRooms(Booking.CheckInDate, Booking.CheckOutDate);
            return Page();
        }
    }
}
