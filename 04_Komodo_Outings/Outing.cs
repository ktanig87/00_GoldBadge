using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    public class Outing
    {
        public Outing() { }
        public Outing(int numberAttendees, DateTime eventDate, decimal perPersonCost, EventType eventType)
        {
            NumberAttendees = numberAttendees;
            EventType = eventType;
            EventDate = eventDate;
            PerPersonCost = perPersonCost;
            
        }
        public int NumberAttendees { get; set; }
        public DateTime EventDate { get; set; }
        public decimal PerPersonCost { get; set; }
        public decimal TotalEventCost 
        { 
            get
            {
                return PerPersonCost * NumberAttendees;
            }
                }


        public EventType EventType { get; set; }
    }
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
}
