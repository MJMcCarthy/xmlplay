using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    class ModifyingNodesContentValuesInAnXMLDocument
    {
        public static void Execute()
        {
            Console.WriteLine("double price");

            XmlDocument doc = new XmlDocument();
            doc.Load("../../books.xml");

            XmlNode bookstore = doc.SelectSingleNode("bookstore");

            XmlNodeList prices = doc.SelectNodes("//price");
            prices = doc.SelectNodes("/bookstore/book/price");
            prices = bookstore.SelectNodes("./book/price");

            foreach(XmlNode price in prices)
            {
                Double priceText = Double.Parse(price.FirstChild.Value);
                price.FirstChild.Value = (priceText * 2).ToString();
            }

            //save
            Console.WriteLine("save the doc to a file ModifyingNodesContentValuesInAnXMLDocument_Double_Price.xml");
            doc.Save("../../ModifyingNodesContentValuesInAnXMLDocument_Double_Price.xml");
        }
    }
}
