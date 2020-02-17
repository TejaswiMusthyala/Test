using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDemo.MockPractice13_02
{
    class Vehicle :IComparable
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        public string RegistrationNo { get => _registrationNo; set => _registrationNo = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public double Weight { get => _weight; set => _weight = value; }
        internal Ticket Ticket { get => _ticket; set => _ticket = value; }
       public static Vehicle CreateVehicle(string detail)
        {
            string[] s = detail.Split(',');
            Ticket t = new Ticket(s[4], DateTime.Parse(s[5]), Double.Parse(s[6]) );
            Vehicle v = new Vehicle(s[0],s[1],s[2],Double.Parse(s[3]),t);
            return v;
        }
        public int CompareTo(Object obj)
        {
            Vehicle v=(Vehicle)obj;
            if (this._weight >= v._weight)
                return 1;
            else
                return -1;
            //return this._weight.CompareTo(v._weight);
        }
    }
    class Ticket
    {
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }

        public string TicketNo { get => _ticketNo; set => _ticketNo = value; }
        public DateTime ParkedTime { get => _parkedTime; set => _parkedTime = value; }
        public double Cost { get => _cost; set => _cost = value; }
    }
    class parkedTimeComparer:IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            //if (x.Ticket.ParkedTime >= y.Ticket.ParkedTime)
            //    return 1;
            //else if(x.Ticket.ParkedTime == y.Ticket.ParkedTime)
            //    return 0;
            //else
            //    return -1;
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
        static void Main(string[] args)
        {

            int n;
            Vehicle v = null;
             Console.WriteLine("Enter the number of the vehicles:");
            n = int.Parse(Console.ReadLine());
            List<Vehicle> lv = new List<Vehicle>();
            parkedTimeComparer p = 
            new parkedTimeComparer();
            for (int i = 0; i < n; i++)
            {               
                v = Vehicle.CreateVehicle(Console.ReadLine());
                lv.Add(v);
            }
            int c;
            

            while (true)
            {
                Console.WriteLine("Enter a type to sort:");

                Console.WriteLine("1.Sort by weight"+"\n2.Sort by parked time");

                c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        lv.Sort();
                        Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", "RegistrationNo", "Name", "Type", "Weight", "TicketNo");
                        for (int i = 0; i < lv.Count; i++)
                        {                                                           
                                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", lv[i].RegistrationNo, lv[i].Name, lv[i].Type, string.Format("{0:0.0}", lv[i].Weight), lv[i].Ticket.TicketNo);
                                                            
                        }                                                                   
                        break;
                    case 2:                        
                        lv.Sort(p);
                        Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", "RegistrationNo", "Name", "Type", "Weight", "TicketNo");
                        for (int i = 0; i < lv.Count; i++)
                        {
                                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", lv[i].RegistrationNo, lv[i].Name, lv[i].Type, string.Format("{0:0.0}", lv[i].Weight), lv[i].Ticket.TicketNo);
                            
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        System.Environment.Exit(0);
                        break;
                }

            }           
        }
    }
    
}
