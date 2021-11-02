using System;
using RRModels;
using Xunit;

namespace RRTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Will test if the city property will set with valid data
        /// valid data - anything with letters only
        /// </summary>
        [Fact] //Fact is a testcase that doesn't have any parameters and will only run once
        public void CityShouldSetValidData()
        {
            //Arrange
            Restaurant _restTest = new Restaurant();
            string city = "Houston";

            //Act
            _restTest.City = city;

            //Assert
            Assert.NotNull(_restTest.City);
            Assert.Equal(_restTest.City, city);
        }

        /// <summary>
        /// Will test if city property gives exception if given invalid data
        /// invalid data - When you add anything beyond letters
        /// </summary>
        [Theory] //Change to Theory to create a parametrize test case
        [InlineData("12353Houston")] //InlineData will be the data being passed to the parameter of this method to be tested on
        [InlineData("12o3islkje")] //You can add more
        [InlineData("l5kae")]
        public void CityShouldFailIfSetWithInvalidData(string p_input)
        {
            //Arrange
            Restaurant _restTest = new Restaurant();

            //Act & Assert
            //Throws method will only pass if the code you did will give some sort of an exception
            Assert.Throws<Exception>(() => _restTest.City = p_input);
        }
    }
}
