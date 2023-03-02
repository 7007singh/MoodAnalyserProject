using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
    public class CustomMoodAnalyserException:Exception
    {
        public ExceptionType exceptionType;
        public enum ExceptionType
        {
            NULL_MOOD,
            EMPTY_MOOD,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND
        }
        public CustomMoodAnalyserException(string message, ExceptionType exceptionType):base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
