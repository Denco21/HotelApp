using HotelAppLibraray.Models;

namespace HotelAppLibraray.Data
{
	public interface IDataBaseData
	{
		void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
		void CheckInGuest(int bookingId);
		List<RoomTypeModel> GetAvailableRooms(DateTime startDate, DateTime endDate);
		RoomTypeModel GetRoomTypeById(int id);
		List<BookingFullModel> SearchBookings(string lastName);
	}
}