using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AI_ZA.Services;
using AI_ZA.Models;
using System.Security.Cryptography.X509Certificates;

namespace AI_ZA
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConversationManager conversationManager;
        private readonly IntentRecognizer intentRecognizer;
        private readonly MemoryManager memoryManager;
        private readonly FactExtractor factExtractor;
        private readonly MLIntentClassifier mlIntentClassifier;
        public MainWindow()
        {
            InitializeComponent();
            conversationManager = new ConversationManager();
            intentRecognizer = new IntentRecognizer();
            memoryManager = new MemoryManager();
            factExtractor = new FactExtractor();

            mlIntentClassifier = new MLIntentClassifier();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            string prediction =
            mlIntentClassifier.PredictIntent(userMessage);

            MessageBox.Show($"ML Predicted: {prediction}");

            if (string.IsNullOrEmpty(userMessage))
                return;

            conversationManager.AddMessage("User", userMessage);

            IntentType intent = intentRecognizer.DetectIntent(userMessage);

            AddUserMessage(userMessage);

            UserInput.Clear();

            //string botResponse = "I received: " + userMessage;

            // string botResponse = $"Detected Intent: {intent}";
            string botResponse;

            switch (intent)
            {
                case IntentType.Greeting:
                    botResponse = "Hello! How can I help you today?";
                    break;

                case IntentType.StoreMemory:

                    if (factExtractor.TryExtractFact(userMessage,
                                    out string key,
                                    out string value))
                    {
                        memoryManager.Remember(key, value);

                        botResponse =
                            $"I've learned that your {key} is {value}.";
                    }
                    else
                    {
                        botResponse =
                            "I couldn't determine what information to store.";
                    }
                    break;

                case IntentType.RecallMemory:

                    string storedName = memoryManager.Recall("Name");

                    if (storedName != null)
                        botResponse = $"Your name is {storedName}.";
                    else
                        botResponse = "I don't know your name yet.";
                    break;

                case IntentType.Question:
                    botResponse = "I detected a question. Knowledge system coming soon.";
                    break;

                default:
                    botResponse = "I'm not sure what you mean yet.";
                    break;
            }



            conversationManager.AddMessage("ZA", botResponse);

            AddBotMessage(botResponse);

         
        }

        private void AddUserMessage(string message)
        {
            Border bubble = new Border
            {
                Background = Brushes.DodgerBlue,
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 5, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            bubble.Child = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap
            };

            MessagesPanel.Children.Add(bubble);
        }

        private void AddBotMessage(string message)
        {
            Border bubble = new Border
            {
                Background = Brushes.Gray,
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 5, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            bubble.Child = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap
            };

            MessagesPanel.Children.Add(bubble);
        }

        
    }
}