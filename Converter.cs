using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Axeptia.Function
{
    public class Converter
    {
        public Converter()
        {

        }

        public List<LineItem> StringToList(String fileAsString)//from string to list<string> to list<LineItem>
        {

            List<LineItem> items = new List<LineItem>();

            List<string> personnelList = fileAsString.Split('\r').ToList();

            for(int i=1;i<personnelList.Count;i++)//'i=1', because we don't need the header line.
            {
                List<String> lineList = personnelList[i].Split(";").ToList();
                LineItem aLineItem = new LineItem();

                //TODO consider adding try/catch in case of error in text file
                aLineItem.firstName = lineList[0];
                aLineItem.lastName = lineList[1];
                aLineItem.title = lineList[2];

                items.Add(aLineItem);
            }

            return items;
        }

        public string ListToJsonFile(List<LineItem> personnel)
        {
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(personnel);//JsonSerializer.Serialize(personnel); returns empty json

            string jsonFileName = "personneljson.json";
            
            //System.IO.File.WriteAllText(@jsonFileName, json);

            //return jsonFileName;
            return json;
        }
        
    }
}