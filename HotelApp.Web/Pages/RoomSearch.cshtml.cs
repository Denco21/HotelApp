using HotelAppLibraray.Data;
using HotelAppLibraray.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
		private readonly IDataBaseData _db;

		[DataType(DataType.Date)]
        [BindProperty(SupportsGet =true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

		[DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
		public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

		[BindProperty(SupportsGet = true)]
		public bool SearchEnabled { get; set; } = false;
        public List<RoomTypeModel> AvailableRoomTypes { get; set; }

        public RoomSearchModel(IDataBaseData db)
        {
			_db = db;
		}
        public void OnGet()
        {
            if (SearchEnabled == true)
            {
				AvailableRoomTypes = _db.GetAvailableRooms(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {
            CultureInfo swedishCulture = new CultureInfo("sv-SE");
            return RedirectToPage("./RoomSearch", new
            { SearchEnabled = true,
				StartDate = StartDate.ToString("yyyy-MM-dd", swedishCulture),
				EndDate = EndDate.ToString("yyyy-MM-dd", swedishCulture)

			});
        }
    }
}
