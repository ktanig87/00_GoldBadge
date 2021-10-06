using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badges
{

    public class BadgeRepository
    {
        //Create- create dictionary for BadgeID, ListofDoors
        public Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();

        //Create - add a new badge
        public bool CreateBadge(Badge badge)
        {
            int startingcount = badgeDictionary.Count;
            badgeDictionary.Add(badge.BadgeID, badge.AccessibleDoors);

            bool wasAdded = badgeDictionary.Count > startingcount;
            return wasAdded;
        }

        //Read - view all badges 
        public Dictionary<int, List<string>> GetBadges()
        {
            return badgeDictionary;
        }


        //Update - add or remove doors from a badge
        public List<string> GetDoorsByID(int soughtID)
        {
            foreach (KeyValuePair<int, List<string>> kvp in badgeDictionary)
            {
                if (soughtID == kvp.Key)
                {
                    return kvp.Value;
                }
            }
            return null;
        }



       
    }
}
