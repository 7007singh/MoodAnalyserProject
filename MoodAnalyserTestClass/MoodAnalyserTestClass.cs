using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]
        [DataRow("I am in Happy Mood", "HAPPY")]
        //[DataRow("I am in Sad Mood", "SAD")]
        //[DataRow("I am in Any Mood", "HAPPY")]
        public void Given_Message_Should_Return_User_Mood(string message, string expected)
        {
            MoodAnalyser mood = new MoodAnalyser();//Arrange
            string actual = mood.AnalyseMood();//Act
            Assert.AreEqual(expected, actual);//Assert
        }

        [TestMethod]
        [DataRow(null, "Object reference not set to an instance of an object.")]
        public void Given_null_Message_Should_Return_User_Exception(string message, string expected)
        {
            
            MoodAnalyser mood = new MoodAnalyser(message);//Arrange
            string actual = mood.AnalyseMood();//Act
            Assert.AreEqual(expected, actual);//Assert
        }
    }
}
