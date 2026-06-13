using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_ZA.Models;

namespace AI_ZA.Services
{
   public class ConversationManager
    {
        private readonly List<ChatMessage> messages;

        public ConversationManager()
        {
            messages = new List<ChatMessage>();
        }

        public void AddMessage(string sender, string message)
        {
            messages.Add(new ChatMessage(sender, message));
        }

        public List<ChatMessage> GetMessages()
        {
            return messages;
        }
    }
}
