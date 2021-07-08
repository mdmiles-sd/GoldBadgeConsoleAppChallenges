using GoldBadgeConsoleAppChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTest
{
    [TestClass]
    public class MenuItemRepoTest
    {
        private MenuRepo _repo;
        private MenuItems _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _item = new MenuItems(1,"Chicken Enchiladas","Juicy cheesy and full of flavour!", "chicken, onion, garlic, refried beans, cheese, cilantro", 7.99m );

            _repo.AddItemToMenu(_item);
        }

        //Add
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //arrange setting up
            MenuItems item = new MenuItems();
            item.MealNumber = 1;
            MenuRepo repo = new MenuRepo();

            //Act run
            repo.AddItemToMenu(item);
            MenuItems itemFromList = repo.GetItemsByMealNumber(1);

            // Asseert verify
            Assert.IsNotNull(itemFromList);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveItemFromList(_item.MealNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
