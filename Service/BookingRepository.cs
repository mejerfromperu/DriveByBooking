using DriveByBooking.Model.Booking;
using DriveByBooking.Model.ProfilFolder;

namespace DriveByBooking.Service
{
    public class BookingRepository : IBookingRepository
    {
        //
        // Instance Field...
        //
        private List<Booking> _repo;

        //
        // Properties...
        //
        public List<Booking> Repository
        {
            get { return _repo; }
            set { _repo = value; }
        }

        //
        // Constructor...
        //
        public BookingRepository()
        {
            _repo = new List<Booking>();


        }


        //
        // Methods...
        // 
        public Booking GetBooking(int id)
        {
            foreach (var booking in _repo)
            {
                if (booking.BookingId == id)
                {
                    return booking;
                }
            }
            return null;
        }


        public void AddBooking(Booking booking)
        {
            _repo.Add(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            _repo.Remove(booking);
        }

        public Booking Delete(int bookingid)
        {
            int index = _repo.FindIndex(Booking => Booking.BookingId == bookingid);
            if (index >= 0)
            {
                Booking DeleteBooking = _repo[index];
                _repo.RemoveAt(index);
                return DeleteBooking;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Repository)}={Repository}}}";
        }
    }
}
