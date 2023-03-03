using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject.Reflaction
{
    public class MoosAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructor)
        {
            string pattern = "." + constructor + "$";//MoodAnalyserProject.MoosAnalyser
            bool result = Regex.IsMatch(className, pattern);
            try
            {
                if (result)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    Activator.CreateInstance(moodAnalyserType);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Class not found");
            }
            throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND);
        }
    }
}
