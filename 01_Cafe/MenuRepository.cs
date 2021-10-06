using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        
        public readonly List<MenuItem> _MenuList = new List<MenuItem>();
        public bool CreateMenuItem(MenuItem menuItem)
        {
            int startingCount = _MenuList.Count;
            _MenuList.Add(menuItem);

            bool addSuccess = (_MenuList.Count > startingCount);
            return addSuccess;
        }

        //see all menu items
        public List<MenuItem> ShowAllMenuItems()
        {
            return _MenuList;
        }

        //public void delete MenuItem()

        public bool DeleteMenuItem(MenuItem existingItem)
        {
            bool result = _MenuList.Remove(existingItem);
            return result;
        }
    }
}
