using DriveByBooking.Model.Booking;

namespace DriveByBooking.Service
{
    public interface IBookingRepository
    {
        List<Booking> Repository { get; set; }

        void AddBooking(Booking booking);
        Booking Delete(int bookingid);
        Booking GetBooking(int id);
        void RemoveBooking(Booking booking);
        string ToString();
    }
}