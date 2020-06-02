using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;



namespace Axeptia.Function
{
    public static class BlobTriggerCSharpTxt2Json
    {
        [FunctionName("BlobTriggerCSharpTxt2Json")]
        public static async Task Run([BlobTrigger("axeptiablob/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            string blobConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
            string blobContainerName = "axeptiablob";

            var Reader = new StreamReader(myBlob);
            var fileAsString = Reader.ReadToEnd();
            Reader.Close();

            BlobClient blobClient = new BlobClient(blobConnectionString, blobContainerName, name);
            Publisher Publisher = new Publisher();
            Converter Converter = new Converter();

            List<LineItem> personnel = Converter.StringToList(fileAsString);

            string jsonFileName = Converter.ListToJsonFile(personnel);

            await Publisher.SetupAndSendMessage(jsonFileName);

            blobClient.DeleteIfExists();

            log.LogInformation($"End of program");
        }
    }
}
