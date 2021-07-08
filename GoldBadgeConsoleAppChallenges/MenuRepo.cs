using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuRepo
    {
        private List<MenuItems> _listofitems = new List<MenuItems>();

        //create
        public void AddItemToMenu(MenuItems item)
        {
            _listofitems.Add(item);
        }

        //Read
        public List<MenuItems> GetMenuItems()
        {
            return _listofitems;
        }

        //Update
        public bool updateExistingItem(int originalMealNumber, MenuItems newItem)
        {
            // Find the item
            MenuItems oldItem = GetItemsByMealNumber(originalMealNumber);

            //update the item
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;
                oldItem.Price = newItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveItemFromList(int mealnumber)
        {
            MenuItems item = GetItemsByMealNumber(mealnumber);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listofitems.Count;
            _listofitems.Remove(item);

            if (initialCount > _listofitems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper Method
        public MenuItems GetItemsByMealNumber(int mealNumber)
        {
            foreach(MenuItems item in _listofitems)
            {
                if(item.MealNumber == mealNumber)
                {
                    return item;
                }
            }

            return null;
        }


    }
}
