using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ZA.Models
{
    public class MemoryItem
    {
        public string Key { get; set; }
        public string Value { get; set;}

        public MemoryItem(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
