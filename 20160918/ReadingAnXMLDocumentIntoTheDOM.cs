using System;
using System.IO;
using System.Xml;

namespace _XMLStudies
{
    //https://msdn.microsoft.com/en-us/library/azsy1tw2(v=vs.110).aspx
    class ReadingAnXMLDocumentIntoTheDOM
    {
        public static void Execute()
        {
            Console.WriteLine("create the XMLDocument from a text string. This uses LoadXml()");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                    "<title>Pride And Prejudice</title>" +
                    "</book>");

            Console.WriteLine("save the doc to a file ReadingAnXMLDocumentIntoTheDOM.xml");
            //doc.Save(@"D:\play\XML_XSLT_XPATH\20160918\20160918\ReadingAnXMLDocumentIntoTheDOM.xml");
            doc.Save("../../ReadingAnXMLDocumentIntoTheDOM.xml");


            Console.WriteLine("create the XMLDocument from an url. This uses Load()");
            doc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");

            Console.WriteLine("save the doc to a file ReadingAnXMLDocumentIntoTheDOM.xml");
            doc.Save("../../ReadingAnXMLDocumentIntoTheDOMUrl.xml");

        }
    }
}
