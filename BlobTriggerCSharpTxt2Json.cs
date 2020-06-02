using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Azure.ServiceBus;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Axeptia.Function
{
    public static class BlobTriggerCSharpTxt2Json
    {
        [FunctionName("BlobTriggerCSharpTxt2Json")]
        public static async Task Run([BlobTrigger("axeptiablob/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            Publisher Publisher = new Publisher();
            Converter Converter = new Converter();


            var Reader = new StreamReader(myBlob);
            var fileAsString = Reader.ReadToEnd();
            Reader.Close();

            //log.LogInformation("fileAsString: " +fileAsString);


            List<LineItem> personnel = Converter.StringToList(fileAsString);

            string jsonFileName = Converter.ListToJsonFile(personnel);




            log.LogInformation("Json file name: " + jsonFileName);


            //TODO publish json file
            await Publisher.SetupAndSendMessage(jsonFileName);



            //TODO delete blob
            /*
                        myBlob.Close();

                        Uri uri = new Uri("http://127.0.0.1:10000/devstoreaccount1/axeptiablob/personnel.txt");
                        var blob = new CloudBlob(uri);

                        Console.WriteLine(blob.IsDeleted);
                        blob.DeleteIfExistsAsync();


                        Console.WriteLine(blob.ToString());

            */

            log.LogInformation($"End of program");
        }
    }
}
