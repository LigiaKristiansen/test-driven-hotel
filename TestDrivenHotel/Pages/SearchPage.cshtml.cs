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
            _repository = new HotelRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSearch()
        {            
            return RedirectToPage("/BookingPage", new { checkInDate = Booking.CheckInDate, checkOutDate = Booking.CheckOutDate });
        }
    }
}

