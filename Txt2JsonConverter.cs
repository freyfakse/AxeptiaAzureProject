using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Axeptia.Function
{
    public class Txt2JsonConverter
    {
        

        public Txt2JsonConverter()//CONSTRUCTOR
        {

        }

        public void TxtToLists(string text)
        {
            List<string> wholeText = null;
            List<string> headerText = null;
            List<string> bodyText = null;

            wholeText = text.Split(";").ToList();

            for(int i=0; i<2;i++)
            {
                headerText[i]=wholeText[i];
            }

            for(int i=3;i<wholeText.Count;i++)
            {
                bodyText[i-3]=wholeText[i];
            }

            for(int i =0;i<wholeText.Count;i++)
            {
                Console.WriteLine(wholeText[i]);
                Console.WriteLine(headerText[i]);
            }
            
            
        }
    }
}