using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Axeptia.Function
{
    public class TxtToJsonConverter
    {
        public TxtToJsonConverter()
        {

        }

        public bool ValidateTextFile()//Check that .txt file from blob has correct format: "Fornavn;Etternavn;Tittel".
        {
            return false;
        }

        public void TxtToList(System.IO.StreamReader file)
        {
            //List<string> wholeText = text.Split(";").ToList();

            //int size = wholeText.Count - 3;// " - 3 ", because header is not to be counted.


        }



        public void ListToJson(List<LineItem> text)
        {
            var json = JsonSerializer.Serialize(text);
        }
    }
}