using KomodoClaimsDepartmentRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsDepartmentTest
{
    [TestClass]
    public class KomodoClaimsTest
    {
        [TestMethod]
        public void SetClaimID()
        {
            ClaimContent content = new ClaimContent();

            content.ClaimID = 123456;

            int expected = 123456;
            int actual = content.ClaimID;

            Assert.AreEqual(expected, actual);
        }
    }
}
