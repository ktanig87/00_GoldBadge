using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeMenu_Tests
{
    [TestClass]
    public class CafeMethodTests
    {
        private MenuRepository _menuRepository = new MenuRepository();

        [TestMethod]
        public void CreateMethod_ShouldReturnCorrectBool()
        {
            //Arrange 
            MenuItem soup = new MenuItem();

            //Act
            bool success = _menuRepository.CreateMenuItem(soup);

            //Assert
            Assert.IsTrue(success);


        }
        [TestMethod]
        public void ShowAllMethod_()
        {
            //Arrange
            MenuItem croissant = new MenuItem(2, "Croissant", "very French", 5.25);

            //act
            List<MenuItem> contents = _menuRepository.ShowAllMenuItems();
            _menuRepository.CreateMenuItem(croissant);

            bool success = contents.Contains(croissant);

            //assert
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void DeleteMethod_ShouldReturnBoolOfTrue()
        {
            //arrange
            MenuItem croissant = new MenuItem(2, "Croissant", "very French", 5.25);
            _menuRepository.CreateMenuItem(croissant);

            //act
            bool removeItem = _menuRepository.DeleteMenuItem(croissant);

            //assert
            Assert.IsTrue(removeItem);
        }
    }
}
