using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.BLL;

namespace TestDrivenHotel.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly HotelRepository _repository;

        [BindProperty]
        public Booking Booking { get; set; }

        public SearchPageModel()
        {
            _repository = new HotelRepository(); // Initialize the repository
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSearch()
        {
            // Redirect to the booking page with search criteria
            return RedirectToPage("/BookingPage", new { checkInDate = Booking.CheckInDate, checkOutDate = Booking.CheckOutDate });
        }
    }
}

