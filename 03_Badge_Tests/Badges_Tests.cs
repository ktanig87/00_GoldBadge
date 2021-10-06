using _03_Komodo_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badge_Tests
{
    [TestClass]
    public class Badges_Tests
    {
        [TestMethod]
        public void CreateBadge_ShouldReturnTrue()
        {
            //arrange
            Badge newBadge = new Badge();
            BadgeRepository badgeRepository = new BadgeRepository();

            //act
            bool success = badgeRepository.CreateBadge(newBadge);

            //assert
            Assert.IsTrue(success);

        }

        [TestMethod]
        public void GetBadges_ShouldReturnCorrectBadgeID()
        {
            //arrange
            Badge newBadgeOne = new Badge(123);
            Badge newBadgeTwo = new Badge(223);
            BadgeRepository badgeRepository = new BadgeRepository();

            //act
            Dictionary<int, List<string>> badgeList = badgeRepository.GetBadges();
            bool success = badgeList.ContainsKey(123);


            //assert
            Assert.AreEqual(newBadgeOne.BadgeID, 123);
        }

        [TestMethod]
        public void GetDoorsByID_result()
        {
            //arrange
            Badge newBadgeOne = new Badge(123);
            newBadgeOne.AccessibleDoors.Add("A2");
            newBadgeOne.AccessibleDoors.Add("B2");

            BadgeRepository badgeRepository = new BadgeRepository();

            //act
            Badge soughtBadge = badgeRepository.GetDoorsByID(123);

            //assert
        }
    }
}
