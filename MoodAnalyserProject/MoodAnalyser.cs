using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
    internal class MoodAnalyser
    {
        public string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            if (message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
    }
}
