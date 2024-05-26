using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Booking_Accomodation;

namespace Booking_Accomodation
{
    public abstract class Accommodation
    {
        private int _ID;

        private string _Name;

        private string _Location;

        private string _City;

        public int ID { get { return _ID; } }
        public string Name { get { return _Name; } }
        public string Location { get { return _Location; } }
        public string City { get { return _City; } }

        public Accommodation(int iD, string name, string location, string city)
        {
            _ID = iD;
            _Name = name;
            _Location = location;
            _City = city;
        }

    }
    public class Room
    {
        private int _ID;
        private string _Name;
        private int _NumofFloor;
        private string _RoomType;
        private int _NumofBed;
        private int _MaxPeople;
        private double _FloorAre;
        private double _Price;

        public int ID { get { return _ID; } }
        public string Name { get { return _Name; } }
        public int NumofFloor { get { return _NumofFloor; } }
        public string RoomType { get { return _RoomType; } }
        public int NumofBed { get { return _NumofBed; } }
        public int MaxPeople { get { return _MaxPeople; } }
        public double FloorArea { get { return _FloorAre; } }
        public double Price { get { return _Price; } }

        public Room(int iD, string name, int numofFloor, string roomType, int numofBed, int maxPeople, double floorAre, double price)
        {
            _ID = iD;
            _Name = name;
            _NumofFloor = numofFloor;
            _RoomType = roomType;
            _NumofBed = numofBed;
            _MaxPeople = maxPeople;
            _FloorAre = floorAre;
            _Price = price;
        }

        public override string ToString()
        {
            string result = "Room [" + ID + "," + Name + "," + NumofFloor +
                "," + RoomType + ", " + NumofBed + "," + MaxPeople +
                "," + FloorArea + "," + Price + "]";
            return result;
        }
    }

    public class Reservation
    {
        private int _reservationId;
        private int _accId;
        private int _roomId;
        private DateTime _checkin;
        private DateTime _checkout;

        public int reservationId { get { return _reservationId; } }
        public int accId { get { return _accId; } }
        public int roomId { get { return _roomId; } }
        public DateTime checkin { get { return _checkin; } }
        public DateTime checkout { get { return _checkout; } }
        public Reservation(int reservationId, int accId, int _roomId, DateTime checkin, DateTime checkout)
        {
            _reservationId = reservationId;
            _accId = accId;
            _roomId = roomId;
            _checkin = checkin;
            _checkout = checkout;

        }
        public override string ToString()
        {
            string result = "Reservation [" + reservationId + "," + accId + "," + roomId +
               "," + checkin + ", " + checkout + "]";
            return result;
        }
    }
    public class CommonAccommodation : Accommodation
    {

        public List<Room> listRoom { get; set; }  = new List<Room> { };
        private float _rate;
        public float Rate { get { return _rate; } set { } }
        public CommonAccommodation(int ID, string name, string location, string city, List<Room> ListRoom, float rate)
            : base(ID, name, location, city)
        {
            listRoom = ListRoom;
            _rate = rate;
        }
        public CommonAccommodation(int ID, string name, string location, string city, float rate)
        : base(ID, name, location, city)
        {
            _rate = rate;
        }

        public void AddRoom(Room room)
        {
             listRoom.Add(room);
        }
    }
    public class Resort : CommonAccommodation
    {
        private float _Star;
        private bool _HaveSwimmingPool;

        public float Star { get { return _Star; } set { } }
        public bool HaveSwimmingPool { get { return _HaveSwimmingPool; } set { } }

        public Resort(int iD, string name, string location, string city, List<Room> rooms, float rate, bool pool, float star)
            : base(iD, name, location, city, rooms, rate)
        {
            _Star = star;
            _HaveSwimmingPool = pool;
        }
        public Resort(int iD, string name, string location, string city, float rate, bool pool, float star)
            : base(iD, name, location, city, rate)
        {
            _Star = star;
            _HaveSwimmingPool = pool;
        }

        public override string ToString()
        {
            string result = "Resort [ " + ID + " , " + Name + " , " + Star + " , " + Location + " , " + HaveSwimmingPool + " , " + City + "]";
            return result;
        }

    }

    public class Homestay : CommonAccommodation
    {
        public Homestay(int iD, string name, string location, string city, List<Room> rooms, float rate)
            : base(iD, name, location, city, rate)
        { }
        public Homestay(int iD, string name, string location, string city, float rate)
            : base(iD, name, location, city, rate)
        { }
        public override string ToString()
        {
            string result = "Homestay [ " + ID + " , " + Name + " , " + Location + " , " + Rate + " , " + City + "]";
            return result;
        }
    }
    public class Hotel : CommonAccommodation
    {
        private double _Quality;
        public double Quality { get { return _Quality; } set { _Quality = value; } }
        public Hotel(int iD, string name, string location, string city, List<Room> rooms, float rate, double quality)
            : base(iD, name, location, city, rate)
        {
            _Quality = quality;
        }
        public Hotel(int iD, string name, string location, string city, float rate, double quality)
            : base(iD, name, location, city, rate)
        {
            _Quality = quality;

        }
        public override string ToString()
        {
            string result = "Hotel [ " + ID + " , " + Quality + " , " + Name + " , " + Location + " , " + City + " ] ";
            return result;
        }
    }
    public class LuxuryAccommodation : Accommodation
    {
        private bool _IsPrivatePool;
        private bool _IsWelcomeDrink;
        private bool _IsFreeBreakFast;
        private bool _IsGym;
        private int _MaxPeople;
        private int _Cost;

        public bool IsPrivatePool { get { return _IsPrivatePool; } set { _IsPrivatePool = value; } }
        public bool IsWelcomeDrink { get { return _IsWelcomeDrink; } set { _IsWelcomeDrink = value; } }
        public bool IsFreeBreakFast { get { return _IsFreeBreakFast; } set { _IsFreeBreakFast = value; } }
        public bool IsGym { get { return _IsGym; } set { _IsGym = value; } }
        public int MaxPeople { get { return _MaxPeople; } }
        public int Cost { get { return _Cost; } set { _Cost = value; } }
        public LuxuryAccommodation(int iD, string name, string location, string city) : base(iD, name, location, city)
        {

        }
        public LuxuryAccommodation(int iD, string name, string location, string city, bool pool, bool drink, bool breakfast, bool gym, int maxPeople, int cost)
            : base(iD, name, location, city)
        {
            _IsPrivatePool = pool;
            _IsWelcomeDrink = drink;
            _IsFreeBreakFast = breakfast;
            _IsGym = gym;
            _MaxPeople = maxPeople;
            _Cost = cost;
        }
    }
    public class Villa : LuxuryAccommodation
    {
        public Villa(int iD, string name, string location, string city, bool pool, bool drink, bool breakfast, bool gym, int maxPeople, int cost)
            : base(iD, name, location, city, pool, drink, breakfast, gym, maxPeople, cost)
        {
           
        }
        public override string ToString()
        {
            string result = "Villa [ " + ID + "," + Name + "," + Location + "," + City + "," + IsPrivatePool + "," + IsWelcomeDrink + "," + IsFreeBreakFast + "," + IsGym + "," +
            MaxPeople + "," + Cost + "]";
            return result;
        }
    }
    public class CruiseShip : LuxuryAccommodation
    {
        private bool _IsPrivateBar;

        public bool IsPrivateBar { get { return _IsPrivateBar; } set { _IsPrivateBar = value; } }

        public CruiseShip(int iD, string name, string location, string city, bool bar, bool pool, bool drink, bool breakfast, bool gym, int maxPeople, int cost)
            : base(iD, name, location, city, pool, drink, breakfast, gym, maxPeople, cost)
        {
            _IsPrivateBar = bar;
        }
        public override string ToString()
        {
            string result = "CruiseShip [" + ID + "," + Name + "," + Location + "," + City + "," + IsPrivateBar + "," + IsPrivatePool + "," + IsWelcomeDrink + "," + IsFreeBreakFast + "," + IsGym + "]";
            return result;
        }
    }
    public class ReservationSystem
    {
        public List<Accommodation> Accommodations = new List<Accommodation>();
        public List<Reservation> Reservations = new List<Reservation>();
        public List<Room> Rooms = new List<Room>();

        public ReservationSystem() { }

        public List<Accommodation> LoadAccommodations(string accPath, string roomPath, string roomOfAccPath)
        {
            Dictionary<int, Accommodation> accommodationMap = new Dictionary<int, Accommodation>();
            Dictionary<int, Room> roomMap = new Dictionary<int, Room>();

            using (StreamReader sr = new StreamReader(accPath))
            {
                string[] lines = File.ReadAllLines(accPath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0].Trim());
                    string name = parts[1].Trim();
                    string location = parts[2].Trim();
                    string city = parts[3].Trim();

                    if (parts.Length == 5)
                    {
                        float rate = float.Parse(parts[4].Trim());
                        accommodationMap[id] = new Homestay(id, name, location, city, rate);
                    }
                    else if (parts.Length == 6)
                    {
                        double quality = double.Parse(parts[5].Trim());
                        float rate = float.Parse(parts[4].Trim());
                        accommodationMap[id] = new Hotel(id, name, location, city, rate, quality);
                    }
                    else if (parts.Length == 7)
                    {

                        float rate = float.Parse(parts[4].Trim());
                        float star = float.Parse(parts[6].Trim());
                        bool swimmingPool = parts[5].Trim().ToLower() == "yes";

                        accommodationMap[id] = new Resort(id, name, location, city, rate, swimmingPool, star);

                    }
                    else if (parts.Length == 10)
                    {
                        bool privatePool = parts[4].Trim().ToLower() == "yes";
                        bool welcomeDrink = parts[5].Trim().ToLower() == "yes";
                        bool freeBreakfast = parts[6].Trim().ToLower() == "yes";
                        bool gym = parts[7].Trim().ToLower() == "yes";
                        int maxPeople = int.Parse(parts[8].Trim());
                        int cost = int.Parse(parts[9].Trim());
                        accommodationMap[id] = new Villa(id, name, location, city, privatePool, welcomeDrink, freeBreakfast, gym, maxPeople, cost);
                    }
                    else if (parts.Length == 11)
                    {
                        bool privateBar = parts[4].Trim().ToLower() == "yes";

                        bool privatePool = parts[5].Trim().ToLower() == "yes";
                        bool welcomeDrink = parts[6].Trim().ToLower() == "yes";
                        bool freeBreakfast = parts[7].Trim().ToLower() == "yes";
                        bool gym = parts[8].Trim().ToLower() == "yes";
                        int maxPeople = int.Parse(parts[9].Trim());
                        int cost = int.Parse(parts[10].Trim());
                        accommodationMap[id] = new CruiseShip(id, name, location, city, privateBar, privatePool, welcomeDrink, freeBreakfast, gym, maxPeople, cost);
                    }
                }
            }
            using (StreamReader reader = new StreamReader(roomPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        int id = int.Parse(parts[0].Trim());
                        string roomName = parts[1].Trim();
                        int floor = int.Parse(parts[2].Trim());
                        string roomType = parts[3].Trim();
                        int bedCount = int.Parse(parts[4].Trim());
                        int capacity = int.Parse(parts[5].Trim());
                        double area = double.Parse(parts[6].Trim());
                        int cost = int.Parse(parts[7].Trim());

                        roomMap[id] = new Room(id, roomName, floor, roomType, bedCount, capacity, area, cost);
                    }
                }
            using (StreamReader reader = new StreamReader(roomOfAccPath))
            {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        int accId = int.Parse(parts[0].Trim());
                        int roomId = int.Parse(parts[1].Trim());

                    if (accommodationMap.ContainsKey(accId) && roomMap.ContainsKey(roomId))
                    {
                        CommonAccommodation accommodation = (CommonAccommodation) accommodationMap[accId];
                        Room room = roomMap[roomId];

                        accommodation.listRoom.Add(room);
                       
                       
                    }
                }
            }

            foreach (var accommodation in accommodationMap.Values)
            {
                Accommodations.Add(accommodation);
            }

            foreach (var room in roomMap.Values)
            {
                Rooms.Add(room);
            }

            return Accommodations;

        }
        public void SaveAccommodations(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var accommodation in Accommodations)
                {
                    writer.WriteLine(accommodation.ToString());
                }
            }
        }

        
    }
}
public class Program
{
    static void Main(string[] args)
    {
        ReservationSystem reservationSystem = new ReservationSystem();
        var accommodations = reservationSystem.LoadAccommodations("accommodation.csv", "room_type.csv", "room_in_accommodation.csv");


        foreach (var accommodation in accommodations)
        {
            if (accommodation is CommonAccommodation)
                Console.WriteLine(((CommonAccommodation)accommodation).listRoom.Count);
        }
        

        Console.ReadLine();
    }

}




