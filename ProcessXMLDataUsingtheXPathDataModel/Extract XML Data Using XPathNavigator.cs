using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Extract_XML_Data_Using_XPathNavigator
    {
        public static void Execute()
        {
            U.header("Node_Set_Navigation_Using_XPathNavigator");

            Console.WriteLine("There are several different ways to represent an XML document in the Microsoft .NET Framework. This includes using a String, or by using the XmlReader, XmlWriter, XmlDocument, or XPathDocument classes.");

            XPathDocument document = new XPathDocument("../../../XMLs/Books.xml");
            XPathNavigator navigator = document.CreateNavigator();


            U.header("String");
            //save entire document ot a string
            string xml = navigator.OuterXml;
            Console.WriteLine(xml);
            Console.WriteLine("###############");
            Console.WriteLine();

            //now Root element and its child nodes
            navigator.MoveToChild(XPathNodeType.Element);
            string root = navigator.OuterXml;
            Console.WriteLine(root);
            Console.WriteLine("###############");
            Console.WriteLine();


            U.header("Convert ann XPathNavigator to an XmlReader");
            navigator = document.CreateNavigator();


            U.wl("stream the entire XML document to the XmlReader");
            XmlReader xmlreader = navigator.ReadSubtree();

            U.wl("write XmlReader to console");
            while (xmlreader.Read())
            {
                Console.WriteLine(xmlreader.ReadInnerXml());
            }

            xmlreader.Close();

            navigator.MoveToChild("bookstore", "");
            navigator.MoveToChild("book", "");

            XmlReader book = navigator.ReadSubtree();
            U.wl("write book, xmlreader for first book,  to console");
            while (book.Read())
            {
                Console.WriteLine(book.ReadInnerXml());
            }


            U.header("XmlWriter");
            XmlWriter writer = XmlWriter.Create("../../../XMLs/newBooks.xml");
            navigator.WriteSubtree(writer);
            

            writer.Close();


        }
    }

}

