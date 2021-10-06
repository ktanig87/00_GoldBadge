using _02_Komodo_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_Claims_Tests
{
    [TestClass]
    public class Claims_test
    {
        


        [TestMethod]
        public void CreateClaim_()
        {
            //arrange
            Claim_POCO newClaim = new Claim_POCO();
            Claims_Repository repository = new Claims_Repository();
            //act

            bool success = repository.CreateClaim(newClaim);

            //assert
            Assert.IsTrue(success);

        }

        [TestMethod]
        public void GetAllClaims()
        {
            //arrange
            Claim_POCO newClaim = new Claim_POCO();
            Claims_Repository repository = new Claims_Repository();
            repository.CreateClaim(newClaim);

            //act
            Queue<Claim_POCO> claims = repository.GetAllClaims();
            bool success = claims.Contains(newClaim);

            //assert
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetNextClaim()
        {
            //no test yet
            //arrange
            Claim_POCO newClaim = new Claim_POCO();
            Claim_POCO newClaim2 = new Claim_POCO();
            Claims_Repository repository = new Claims_Repository();
            repository.CreateClaim(newClaim);
            repository.CreateClaim(newClaim2);

            //act
            Claim_POCO claim = repository.GetNextClaim();

            //assert
            Assert.AreEqual(newClaim, claim);
        }
    }
}
