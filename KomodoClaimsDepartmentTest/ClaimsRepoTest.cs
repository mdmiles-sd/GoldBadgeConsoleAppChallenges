using KomodoClaimsDepartmentRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsDepartmentTest
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private ClaimsReop _repo;
        private ClaimContent _content;

        [TestInitialize]
            public void Arrange()
        {
            _repo = new ClaimsReop();
            _content = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018,04,25),new DateTime(2018,04,27), true);

            _repo.AddContentToList(_content);
        }


        [TestMethod]
        public void AddToList_NotNull()
        {
            //Arrange 
            ClaimContent content = new ClaimContent();
            content.ClaimID = 1;
            ClaimsReop repo = new ClaimsReop();

            //Act (run)
            repo.AddContentToList(content);
            ClaimContent contentFromDirectory = repo.GetClaimByClaimID(1);
            //Assert 
            Assert.IsNotNull(contentFromDirectory);
        }

        //Update
        [TestMethod]
        public void updateClaim()
        {
            //arrange
            //test init
            ClaimContent newContent = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), false);

            //act
            bool updateResult = _repo.UpdateExistingContent(1, newContent);

            // Assert
            Assert.IsTrue(updateResult);

        }

        public void DeleteContent()
        {
            //arrange

           //Act
           bool deleteResult = _repo.RemoveContentFromList(_content.ClaimID);

            //Assert
            Assert.IsTrue(deleteResult);
        }







    }
}
