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

            var Reader = new StreamReader(myBlob);
            var fileAsString = Reader.ReadToEnd();
            Reader.Close();

            //log.LogInformation("fileAsString: " +fileAsString);

            Publisher Publisher = new Publisher();
            Converter Converter = new Converter();

            List<LineItem> personnel = Converter.StringToList(fileAsString);

            //Converter.ListToJson(personnel);

            

            String json = JsonSerializer.Serialize(personnel);

             log.LogInformation(json);


            //TODO publish json file


            log.LogInformation($"End of program");
        }
    }
}
