using System;

namespace MoodAnalyserProject
{
    public class MoodAnalyser
    {
        public string message = "I am in happy mood";
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public MoodAnalyser() 
        { 
        }
        public string AnalyseMood()
        {
            try
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
            catch(NullReferenceException ex) 
            {
                Console.WriteLine(ex.Message);
                throw new CustomMoodAnalyserException("Message is null", CustomMoodAnalyserException.ExceptionType.NULL_MOOD);
            }
        }
    }
}
