using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_ZA.Models;

namespace AI_ZA.Services
{
    public class IntentRecognizer
    {
        public IntentType DetectIntent(string message)
        {
            string input = message.ToLower();

            if (input.Contains("my name is"))
            {
                return IntentType.StoreMemory;
            }

            if (input.Contains("what is my name"))
            {
                return IntentType.RecallMemory;
            }

            if (input.Contains("hello") ||
                input.Contains("hi") ||
                input.Contains("hey"))
            {
                return IntentType.Greeting;
            }

            if (input.StartsWith("what") ||
                input.StartsWith("who") ||
                input.StartsWith("where") ||
                input.StartsWith("when") ||
                input.StartsWith("why") ||
                input.StartsWith("how"))
            {
                return IntentType.Question;
            }

            return IntentType.Unknown;
        }
    }
}
