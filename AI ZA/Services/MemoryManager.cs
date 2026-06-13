using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace AI_ZA.Services
{
    public class MemoryManager
    {
        private readonly Dictionary<string, string> memories;
        private const string MemoryFile = "memory.json";
        public MemoryManager()
        {
            //memories = new Dictionary<string, string>();

            if (File.Exists(MemoryFile))
            {
                string json = File.ReadAllText(MemoryFile);

                memories = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                           ?? new Dictionary<string, string>();
            }
            else
            {
                memories = new Dictionary<string, string>();
            }
        }

        public void Remember(string key, string value)
        {
            memories[key] = value;
            SaveMemory();
        }

        public string Recall(string key)
        {
            if (memories.ContainsKey(key)) 
                return memories[key];

            return null;
        }

        private void SaveMemory()
        {
            string json = JsonSerializer.Serialize(memories, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(MemoryFile, json);
        }
    }
}
