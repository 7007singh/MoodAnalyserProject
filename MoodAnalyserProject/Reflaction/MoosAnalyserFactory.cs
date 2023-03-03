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
            string pattern = @"." + constructor + "$";//MoodAnalyserProject.MoodAnalyser
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch(ArgumentNullException)
                {
                    throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }
}
