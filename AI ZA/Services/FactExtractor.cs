using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ZA.Services
{
    public class FactExtractor
    {
        public bool TryExtractFact(string input, out string key, out string value)
        {
            input = input.ToLower();

            key = "";
            value = "";

            if (input.Contains("my name is"))
            {
                key = "Name";
                value = input.Replace("my name is", "").Trim();
                return true;
            }

            if (input.Contains("my favourite game is"))
            {
                key = "FavouriteGame";
                value = input.Replace("my favourite game is", "").Trim();
                return true;
            }

            if (input.Contains("my favourite color is"))
            {
                key = "FavouriteColor";
                value = input.Replace("my favourite color is", "").Trim();
                return true;
            }

            return false;
        }
    }
}