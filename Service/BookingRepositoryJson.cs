using DriveByBooking.Model.Booking;
using DriveByBooking.Model.CarFolder;
using System.Text.Json;

namespace DriveByBooking.Service
{
    public class BookingRepositoryJson : IBookingRepository
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
        public BookingRepositoryJson()
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
            WriteToJson();
        }

        public void RemoveBooking(Booking booking)
        {
            _repo.Remove(booking);
            WriteToJson();
        }

        public Booking Delete(int bookingid)
        {
            int index = _repo.FindIndex(Booking => Booking.BookingId == bookingid);
            if (index >= 0)
            {
                Booking DeleteBooking = _repo[index];
                _repo.RemoveAt(index);
                WriteToJson();
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


        private const string FILENAME = "CarRepository.json";

        private List<Booking>? ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                List<Booking>? book = JsonSerializer.Deserialize<List<Booking>>(sr.ReadToEnd());
                sr.Close();
                return book;
            }
            else
            {
                return new List<Booking>();
            }
        }


        // HAck quick fix - burde lave en metode Edit
        public void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _repo);
            fs.Close();
        }
    }
}
