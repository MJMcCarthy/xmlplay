using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class SelectXMLDataUsingXPathNavigator
    {
        public static void Execute()
        {
            U.header("SelectXMLDataUsingXPathNavigator");

            //*************************************************
            //XPathDocument
            //*************************************************
            Console.WriteLine("New XPathDocument");
            XPathDocument xpathdoc = new XPathDocument("../../../XMLs/inventory.xml");

            XPathNavigator xPathDocNav = xpathdoc.CreateNavigator();

            //1. Select()
            //these are the style attributes
            XPathNodeIterator styleAtttributes = xPathDocNav.Select("/bookstore/book/@style");

            //these are the books with style attributes equal to 
            XPathNodeIterator bookAutobiographies = xPathDocNav.Select("/bookstore/book[@style='autobiography']");

            //2. SelectSingleNode()
            //these are the style attributes
            var whatTheHellAmI = xPathDocNav.SelectSingleNode("/bookstore/book[@style='autobiography']");
            //what get's returned from SelectSingleNode()
            Console.WriteLine(whatTheHellAmI.GetType()); //Hell! I am a XPathNavigator like the documentation says!

            
            //*************************************************
            //XmlDocument
            //*************************************************
            Console.WriteLine("New XmlDocument");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("../../../XMLs/inventory.xml");

            XPathNavigator xmlNav = xmldoc.CreateNavigator();

            //1. Select()
            //these are the style attributes
            XPathNodeIterator styleAtttributes1 = xmlNav.Select("/bookstore/book/@style");

            //these are the books with style attributes equal to 
            XPathNodeIterator bookAutobiographies1 = xmlNav.Select("/bookstore/book[@style='autobiography']");

            //2. SelectSingleNode()
            //these are the style attributes
            var whatTheHellAmI1 = xPathDocNav.SelectSingleNode("/bookstore/book[@style='autobiography']");
            //what get's returned from SelectSingleNode()
            Console.WriteLine(whatTheHellAmI1.GetType()); //Hell! I am a XPathNavigator like the documentation says!









        }
    }
}
