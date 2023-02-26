using System;

namespace MoodAnalyserProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___Welcome to mood analyzer program___");
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            moodAnalyser.AnalyseMood();
        }
    }
}
