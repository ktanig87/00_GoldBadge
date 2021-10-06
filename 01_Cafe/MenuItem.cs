using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItem
    {
        public MenuItem(int mealNumber, string mealName, string mealDescription, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;

        }
        public MenuItem() { }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public List<string> IngredientList { get; set; } = new List<string>();
    }
}
