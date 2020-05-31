using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;


namespace Axeptia.Function
{
    public static class BlobTriggerCSharpTxt2Json
    {
        [FunctionName("BlobTriggerCSharpTxt2Json")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            Txt2JsonConverter MyConverter = new Txt2JsonConverter();

            MyConverter.TxtToLists("fornavn;etternavn;tittel;hans;gretesen;kokk");
        }
    }
}
