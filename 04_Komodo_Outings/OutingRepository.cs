using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    public class OutingRepository
    {
        public readonly List<Outing> _OutingsList = new List<Outing>();
        //Display all outings
        public List<Outing> GetOutings()
        {
            return _OutingsList;
        }

        //add outings to a list 
        public bool AddOuting(Outing outing)
        {
            int startCount = _OutingsList.Count;
            _OutingsList.Add(outing);

            bool wasAdded = _OutingsList.Count > startCount;
            return wasAdded;
        }

        //Calculate total combined costs 
        public decimal CombinedCosts()
        {
            int index = 1;
            decimal runningTotal = 0;

            foreach (Outing outing in _OutingsList)
            {
                if (index <= _OutingsList.Count)
                {
                    runningTotal += outing.TotalEventCost;
                    index++;
                }
            }
            return runningTotal;

        }

        //Calculate cost of outing by type
        public decimal CostByOutingType(Outing outingType)  //parameters need to change?
        {
            decimal cost = 0;
            foreach (Outing outing in _OutingsList)
            { 
                if(outing.EventType == outingType.EventType)
                {
                    cost += outing.TotalEventCost;
                }
            }
            return cost;
        }
    }
}
