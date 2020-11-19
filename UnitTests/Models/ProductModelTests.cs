using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using HWUT.Models;

namespace UnitTests
{
    [TestClass]
    public class ProductModelTests
    {
        [TestMethod]
        public void ProductModel_Valid_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ProductModel();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProductModel_Valid_Get_Date_Default_Should_Return_Date()
        {
            // Arrange

            // Act
            var result = new ProductModel();

            // Assert
            Assert.AreEqual(DateTime.UtcNow.ToShortDateString(), result.Date.ToShortDateString());
        }

        [TestMethod]
        public void AverageRating_Rating_isNull_shouldReturnZero()
        {
            // Arrange
            var model = new ProductModel();
            model.Ratings = null;
            var expected = 0;


            // Act
            var actual = model.AverageRating();
            

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageRating_countIsZero_ReturnZero()
        {
            // Arrange
            var model = new ProductModel();
            model.Ratings = new int[] { };
            var expected = 0;


            // Act
            var actual = model.AverageRating();


            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageRating_totalEqualsZeroReturnZero()
        {
            // Arrange
            var model = new ProductModel();
            model.Ratings = new int[] { -5, 5};
            var expected = 0;


            // Act
            var actual = model.AverageRating();


            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AverageRating_happyPath()
        {
            // Arrange
            var model = new ProductModel();
            model.Ratings = new int[] {0, -3, 6};
            var expected = 1;


            // Act
            var actual = model.AverageRating();


            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void toString()
        {
            // Arrange
            var model = new ProductModel();
            model.Id = "4356";
            model.Maker = "Rich";
            model.Image = "flower";
            model.Url = "rapaugustino.com";
            model.Title = "Student";
            model.Description = "CS";
            model.Date = DateTime.Parse("11/18/2020");
            model.Sequence = "Ten";
            model.Email = "rap@seattleu.edu";
            model.Logistics = "Get there by bus";
            model.Ratings = new int[] { 2, 3, 4};
            var expected = "{\"Id\":\"4356\",\"Maker\":\"Rich\",\"img\":\"flower\",\"Url\":\"rapaugustino.com\",\"Title\":\"Student\",\"Description\":\"CS\",\"Date\":\"2020-11-18T00:00:00\",\"Sequence\":\"Ten\",\"Email\":\"rap@seattleu.edu\",\"Logistics\":\"Get there by bus\",\"Ratings\":[2,3,4]}";


            // Act
            var actual = model.ToString();


            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}