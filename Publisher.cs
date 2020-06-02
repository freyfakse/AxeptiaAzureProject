using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;


namespace Axeptia.Function
{
    public class Publisher
    {
        const string ServiceBusConnectionString = "Endpoint=sb://axeptiaservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1ttHzjpZLCONO2iwRggV+OdIFCoyq0Xaq+jIlHed4q4=";
        const string TopicName = "personnelinfo";
        static ITopicClient topicClient;

        public Publisher() 
        {

        }

        public static async Task SetupAndSendMessage(string jsonFileName)
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            await SendMessage(jsonFileName);

            await topicClient.CloseAsync();
        }


        static async Task SendMessage(string jsonFileName)
        {
            try
            {
                    var messageBody = jsonFileName;
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    await topicClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }

    }
}