using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badges
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID)
        {
            BadgeID = badgeID;
        }

        public int BadgeID { get; set; }
        public List<string> AccessibleDoors { get; set; } = new List<string>();
    }
}
