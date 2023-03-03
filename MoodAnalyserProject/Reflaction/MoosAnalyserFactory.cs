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
            if (result)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    Activator.CreateInstance(moodAnalyserType);
                }
                catch (Exception)
                {
                    Console.WriteLine("Constructor not found");
                }
            }
            //throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND);
            throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND);
        }
    }
}
