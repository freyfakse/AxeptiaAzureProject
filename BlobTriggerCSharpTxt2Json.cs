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
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");



            //TxtToJsonConverter MyConverter = new TxtToJsonConverter();

            //MyConverter.TxtToList("fornavn;etternavn;tittel;hans;gretesen;kokk");




            List<LineItem> items = null;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Backup\Github\AxeptiaAzureProject\personnel.txt");
            while ((line = file.ReadLine()) != null)
            {
                List<string> lineList = line.Split(";").ToList();

                int i = 0;

                items[i].firstName = lineList[0];
                items[i].lastName = lineList[1];
                items[i].title = lineList[2];

                i++;
            }
            file.Close();

            items.RemoveAt(0);//remove header element

            var json = JsonSerializer.Serialize(items);

            //TODO publish json file

        }
    }
}
