using System;
using System.IO;
using System.Xml;

namespace _XMLStudies
{
    class AccessingAttributesInTheDOM
    {
        public static void Execute()
        {
            XmlDocument doc = new XmlDocument();
            //doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5' misc='sale item'>" +
            //              "<title>The Handmaid's Tale</title>" +
            //              "<price>14.95</price>" +
            //              "</book>");
            //doc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            //doc.Load(@"D:\play\XML_XSLT_XPATH\20160918\20160918\books.xml");
            doc.Load("../../books.xml");


            // Move to an element.
            XmlNode root = doc.DocumentElement;

            //XmlNodeList nodes = root.SelectNodes("//Cube");
            //XmlNodeList nodes = root.SelectNodes("/Cube/Cube/Cube");
            //XmlNodeList nodes = root.SelectNodes("descendant::Cube");
            //XmlNodeList nodes = root.SelectNodes("Cube/Cube/Cube");
            //XmlNodeList nodes = root.SelectNodes("Cube/*/Cube");
            //XmlNodeList nodes = root.SelectNodes("/gesmes:Envelope/Cube/Cube/Cube/Cube");
            //XmlNodeList nodes = root.SelectNodes("/gesmes:Envelope/Cube/Cube/Cube/Cube");
            //XmlNodeList nodes = root.SelectNodes("gesmes:Envelope/Cube/Cube/Cube/Cube");
            //XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
            //manager.AddNamespace("gesmes", "http://www.gesmes.org/xml/2002-08-01");
            //XmlNodeList nodes = root.SelectNodes("gesmes:Envelope/Cube", manager);
            //XmlNodeList nodes = root.SelectNodes("//Cube", manager);
            //XmlNodeList nodes = root.SelectNodes("/gesmes:Envelope/Cube", manager);
            //XmlNodeList nodes = doc.SelectNodes("/gesmes:Envelope/Cube", manager);
            //XmlNodeList nodes = doc.SelectNodes("gesmes:Envelope/Cube", manager);
            //XmlNodeList nodes = doc.SelectNodes("//Cube");
            //XmlNodeList nodes = doc.SelectNodes("*"); //this gets us gesmes:Envelope
            //XmlNodeList nodes = doc.SelectNodes("//*"); //this got us all nodes
            
            XmlNodeList nodes = doc.SelectNodes("//book"); //this works
            nodes = doc.SelectNodes("book"); //count = 0
            nodes = doc.SelectNodes("bookstore/book"); //this works

            foreach (XmlNode node in nodes)
            {
                // Create an attribute collection from the element.
                XmlAttributeCollection attrColl = node.Attributes;

                // Show the collection by iterating over it.
                //Console.WriteLine("Display all the attributes in the collection...");
                for (int i = 0; i < attrColl.Count; i++)
                {
                    Console.Write("{0} = ", attrColl[i].Name);
                    Console.Write("{0}", attrColl[i].Value);
                    Console.WriteLine();
                }

                //// Retrieve a single attribute from the collection; specifically, the
                //// attribute with the name "misc".
                //XmlAttribute attr = attrColl["misc"];

                //// Retrieve the value from that attribute.
                //String miscValue = attr.InnerXml;

                //Console.WriteLine("Display the attribute information.");
                //Console.WriteLine(miscValue);
            }

        }
    }
}

