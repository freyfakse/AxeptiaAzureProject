using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;


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




            List<LineItem> itemList = null;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Backup\Github\AxeptiaAzureProject\personnel.txt");
            while ((line = file.ReadLine()) != null)
            {
                List<string> lineList = line.Split(";").ToList();

                int i = 0;

                itemList[i].firstName = lineList[0];
                itemList[i].lastName = lineList[1];
                itemList[i].title = lineList[2];

                i++;
            }
            itemList.RemoveAt(0);//remove header element

            file.Close();
        }
    }
}
