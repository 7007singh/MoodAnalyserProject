using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject.Reflaction
{
    public class MoodAnalyserFactory
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
        public static object CreateMoodAnalyserObjectWithParameterizedObject(string className, string constructor, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Contains(className) || type.FullName.Contains(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                return default;
            }
            else
            {
                throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND);
            }
        }
    }
}
