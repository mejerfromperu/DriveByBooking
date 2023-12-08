using DriveByBooking.Model.Booking;
using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using System;

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
        public BookingRepository(bool mocData = false)
        {
            _repo = new List<Booking>();

            if (mocData)
            {
                CarClass car1 = new CarClass("YH40393", "AMG", "Mercedes", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "aalborg");
                CustomerClass customer1 = new CustomerClass("Christianmejer7@gmail.com", "11223344", 1, "MidgetSlayer", "hundogcat", "chris", false, false);
                DateTime date1 = DateTime.Now;
                _repo.Add(new Booking(car1, customer1, date1));

                CarClass car2 = new CarClass("AH40393", "Aygo", "Toyota", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg");
                CustomerClass customer2 = new CustomerClass("Christiane23@gmail.com", "83728390", 2, "MidgetHunter", "missecat", "chrissi", true, true);
                DateTime date2 = DateTime.Now;
                _repo.Add(new Booking(car2, customer2, date2));

                // Repeat the above process for other instances...

                CarClass car3 = new CarClass("YB40393", "206", "Peugeot", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg");
                CustomerClass customer3 = new CustomerClass("starshipcaptain@emailgalaxy.org", "98982626", 3, "MidgetFucker", "katapult", "mejer", false, false);
                DateTime date3 = DateTime.Now;
                _repo.Add(new Booking(car3, customer3, date3));

                CarClass car4 = new CarClass("CH40393", "206cc", "Peugeot", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg");
                CustomerClass customer4 = new CustomerClass("pixieprogrammer@emailmagic.com", "44667728", 4, "MidgetFinder", "YESSIR", "mejerfromperu", false, false);
                DateTime date4 = DateTime.Now;
                _repo.Add(new Booking(car4, customer4, date4));

                CarClass car5 = new CarClass("YG40393", "500", "Fiat", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg");
                CustomerClass customer5 = new CustomerClass("codingwizard42@techfantasy.net", "87653542", 5, "MidgetTaker", "taxi", "christian", false, false);
                DateTime date5 = DateTime.Now;
                _repo.Add(new Booking(car5, customer5, date5));
            }
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


        public List<Booking> GetAllbookings()
        {
            return _repo;
        }
        

        public override string ToString()
        {
            return $"{{{nameof(Repository)}={Repository}}}";
        }
    }
}
