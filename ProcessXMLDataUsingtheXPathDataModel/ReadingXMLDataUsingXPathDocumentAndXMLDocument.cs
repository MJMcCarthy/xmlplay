using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class ReadingXMLDataUsingXPathDocumentAndXMLDocument
    {

        public static void Execute()
        {
            U.header("ReadingXMLDataUsingXPathDocumentAndXMLDocument");

            Console.WriteLine("New XPathDocument");
            XPathDocument xpathdoc = new XPathDocument("../../../XMLs/inventory.xml");


            Console.WriteLine("New XmlDocument");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("../../../XMLs/inventory.xml");

            XmlNodeList list = xmldoc.SelectNodes("/bookstore/book");
        }
    }
}
