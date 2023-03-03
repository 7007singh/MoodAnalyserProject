﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using MoodAnalyserProject.Reflaction;

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
        [DataRow("MoodAnalyserProject.MoodAnalyser", "CustomMoodAnalyserException")]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object(string className, string constructor)
        {
            //string expectedMessage = "Class not found";
            string expectedResult = "Constructor not found";
            try
            {
                MoodAnalyser expected = new MoodAnalyser();
                object actual = MoosAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
                expected.Equals(actual);
            }
            catch(CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expectedResult, ex.Message);
            }
        }
    }
}
