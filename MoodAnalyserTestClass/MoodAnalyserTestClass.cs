using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using MoodAnalyserProject.Reflaction;
using System.Globalization;

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
        //[DataRow(null, "HAPPY")]
        public void Given_Empty_Message_Should_Return_User_Exception()
        {
            string message = "";
            string expected = "Message is empty";
            try
            {
                MoodAnalyser mood = new MoodAnalyser(message);//Arrange
                string actual = mood.AnalyseMood();//Act
                Assert.AreEqual(expected, actual);//Assert
            }
            catch(CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Reflaction")]
        [DataRow("MoodAnalyserProject.Contact", "Contact")]
        //[DataRow("MoodAnalyserProject.MoodAnalyser", "Customer")]
        //[DataRow("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser")]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object(string className, string constructor)
        {
            string expectedMessage = "Class not found";
            //string expectedResult = "Constructor not found";
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
                expected.Equals(actual);
            }
            catch(CustomMoodAnalyserException ex)
            {
                //Assert.AreEqual(expectedResult, ex.Message);
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Reflaction")]
        [DataRow("MoodAnalyserProject.Contact", "Contact")]
        public void Given_MoodAnalyserWithMessage_Using_Reflaction_Return_ParameterizedConstructor(string className, string constructor)
        {
            try
            {
                string message = "Class not found";
                MoodAnalyser expected = new MoodAnalyser(message);
                object actual = MoodAnalyserFactory.CreateMoodAnalyserObjectWithParameterizedObject(className, constructor, message);
                expected.Equals(actual);
            }
            catch(CustomMoodAnalyserException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
    }
}
