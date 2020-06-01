using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Azure.ServiceBus;

namespace Axeptia.Function
{
    public static class BlobTriggerCSharpTxt2Json
    {
        [FunctionName("BlobTriggerCSharpTxt2Json")]
        public static void Run([BlobTrigger("axeptiablob/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");



            //TxtToJsonConverter MyConverter = new TxtToJsonConverter();

            //MyConverter.TxtToList("fornavn;etternavn;tittel;hans;gretesen;kokk");

            
            


            List<LineItem> items = new List<LineItem>();
            //items.Add(li);
            string line;

            List<string> lineList = new List<string>();

            //System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Backup\Github\AxeptiaAzureProject\personnel.txt");
/*
            while ((line = name.ReadLine()) != null)
            {
                lineList = line.Split(";").ToList();

                int i = 0;

                LineItem li = new LineItem();
                items.Add(li);

                items[i].firstName = lineList[0];
                items[i].lastName = lineList[1];
                items[i].title = lineList[2];
                log.LogInformation(items[i].firstName +items[i].lastName +items[i].title);

                i++;
            }

            log.LogInformation(items[0].firstName +" " +items[0].lastName +" " +items[0].title);



            file.Close();
*/
            items.RemoveAt(0);//remove header element

            var json = JsonSerializer.Serialize(items);

            //TODO publish json file
            Publisher MessageSender = new Publisher();

            log.LogInformation($"End of program");
        }
    }
}
