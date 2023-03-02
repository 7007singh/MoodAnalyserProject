using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject.Reflaction
{
    internal class MoosAnalyserFactory
    {
        public static void CreateMoodAnalyserObject(string className, string constructor)
        {
            string pattern = "." + constructor + "$";//MoodAnalyserProject.MoosAnalyser
            bool result = Regex.IsMatch(className, pattern);

            if (result)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalyserType = assembly.GetType(className);
                Activator.CreateInstance(moodAnalyserType);
            }
        }
    }
}
