using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.Json;

namespace Axeptia.Function
{
    public class Converter
    {
        public Converter()
        {

        }

        public List<LineItem> StringToList(String fileAsString)
        {

            List<LineItem> items = new List<LineItem>();

            List<string> personnelList = fileAsString.Split('\r').ToList();

            for(int i=1;i<personnelList.Count;i++)//'i=1', because we don't need the header line.
            {
                List<String> lineList = personnelList[i].Split(";").ToList();
                LineItem aLineItem = new LineItem();

                aLineItem.firstName = lineList[0];
                aLineItem.lastName = lineList[1];
                aLineItem.title = lineList[2];

                items.Add(aLineItem);
            }

            return items;
        }

        public void ListToJson(List<LineItem> items)
        {
            
            //return json;

        }
        
    }
}