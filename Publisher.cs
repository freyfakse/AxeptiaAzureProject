using System.Text;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;


namespace Axeptia.Function
{
    public class Publisher
    {
        //const string ServiceBusConnectionString = "AxeptiaServiceBus.servicebus.windows.net";
        //const Uri ServiceBusConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
        const string ServiceBusConnectionString = "Endpoint=sb://axeptiaservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1ttHzjpZLCONO2iwRggV+OdIFCoyq0Xaq+jIlHed4q4=";
        const string key = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
        const string TopicName = "personnelinfo";
        static ITopicClient topicClient;

        public Publisher() 
        {

        }

        public static async Task SetupAndSendMessage(string jsonFileName)
        {
            //const int numberOfMessages = 1;
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            // Send messages.
            //await SendMessages(numberOfMessages);

            await SendMessage(jsonFileName);

            await topicClient.CloseAsync();
        }


        static async Task SendMessage(string jsonFileName)
        {
            try
            {
                    var messageBody = jsonFileName;
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    //var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the topic.
                    await topicClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }

    }
}