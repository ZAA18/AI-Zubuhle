using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ZA.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }

        public ChatMessage(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }
}
