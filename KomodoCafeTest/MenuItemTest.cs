using GoldBadgeConsoleAppChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTest
{
    [TestClass]
    public class MenuItemTest
    {
        [TestMethod]
        public void SetItem_ShouldSetCorrectInt()
        {
            MenuItems item = new MenuItems();

            item.MealNumber = 1;

            int expected = 1;
            int actual = item.MealNumber;

            Assert.AreEqual(expected, actual);
        }
    }
}
