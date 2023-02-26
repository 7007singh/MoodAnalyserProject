using System;

namespace MoodAnalyserProject
{
    public class MoodAnalyser
    {
        public string message = "I am in Sad Mood";

        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public MoodAnalyser() 
        { 
        }
        public string AnalyseMood()
        {
            if (message.ToLower().Contains("sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }
}
