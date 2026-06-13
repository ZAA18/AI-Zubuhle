using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ZA.Services
{
    public class MemoryManager
    {
        private readonly Dictionary<string, string> memories;

        public MemoryManager()
        {
            memories = new Dictionary<string, string>();
        }

        public void Remember(string key, string value)
        {
            memories[key] = value;
        }

        public string Recall(string key)
        {
            if (memories.ContainsKey(key)) 
                return memories[key];

            return null;
        }
    }
}
