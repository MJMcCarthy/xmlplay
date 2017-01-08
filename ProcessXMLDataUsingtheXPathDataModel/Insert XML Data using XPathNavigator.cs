using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Insert_XML_Data_using_XPathNavigator
    {
        public static void Execute()
        {
            U.header("Node_Set_Navigation_Using_XPathNavigator");

            string str = "The XPathNavigator class provides methods to insert sibling, child, and attribute nodes in an XML document. These methods allow you to insert nodes and attributes in different locations in relation to the current position of an XPathNavigator object and are described in the following sections.";

            Console.WriteLine(str);

            U.header("INSERT methods");

            //XPathDocument  document= new XPathDocument("../../../XMLs/Books.xml"); //this won't work because XpathDocument is read only, forward NotSupportedException
            XmlDocument document = new XmlDocument();
            document.Load("../../../XMLs/Books.xml");

            XPathNavigator navigator = document.CreateNavigator();

            navigator.MoveToChild("bookstore", "");
            navigator.MoveToChild("book", "");
            navigator.MoveToChild("price", "");

            navigator.InsertAfter("<pages>100</pages>");

            navigator.MoveToRoot();
            Console.WriteLine(navigator.OuterXml);

            //let's try this in a more complete way
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../XMLs/Books.xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator itr = nav.Select("/bookstore/book/price");
            int ct = 100;
            while (itr.MoveNext())
            {
                XPathNavigator navInsert = itr.Current.CreateNavigator();
                navInsert.InsertAfter("<pages>" + ct++ + "</pages>"); //OH! Could have just used itr.Current rather than nav1!
            }

            U.header("Doc OuterXml");
            Console.WriteLine(doc.OuterXml);

            U.header("nav OuterXml");
            Console.WriteLine(nav.OuterXml);


            U.header("APPEND and PREPEND methods");
            //reload nav
            nav = doc.CreateNavigator();
            nav.MoveToChild("bookstore", "");
            nav.MoveToChild("book", "");

            nav.AppendChild("<pages>100</pages>");
            U.header("nav OuterXml with Append <pages>");
            U.wl(nav.OuterXml);


            nav.MoveToNext();
            nav.PrependChild("<pages>100</pages>");
            U.header("nav OuterXml with Prepend <pages>");
            U.wl(nav.OuterXml);


            U.header("Inserting Attribute methods CreateaAttribute() CreateAttributes()");
            nav = doc.CreateNavigator();
            itr = nav.Select("/bookstore/book/price");

            while (itr.MoveNext())
            {
                XmlWriter attributes = itr.Current.CreateAttributes();
                attributes.WriteAttributeString("discount", "1.00");
                attributes.WriteAttributeString("currency", "USD");
                attributes.Close();
            }

            U.header("nav OuterXml after adding attributes discount and currency to price");
            U.wl(nav.OuterXml);

            //copy nodes to a document
            U.header("Copying nodes");
            XPathNavigator navOriginal = doc.CreateNavigator();

            navOriginal.MoveToChild("bookstore", "");


            XPathDocument newBooks = new XPathDocument("../../../XMLs/booksCopy.xml");
            XPathNavigator navNewBooks = newBooks.CreateNavigator();
            
            foreach (XPathNavigator navRepeater in navNewBooks.SelectDescendants("book", "", false))
            {
                navOriginal.AppendChild(navRepeater);
            }

            doc.Save("../../../XMLs/booksCopy.xml");


            //insert untyped values
            U.header("Insert untyped values");
            doc.Load("../../../XMLs/booksCopy.xml");
            nav = doc.CreateNavigator();

            foreach (XPathNavigator navEach in nav.Select("//price"))
            {
                if (navEach.Value == "49.95")
                {
                    navEach.SetValue("49.96");
                }
            }
            U.wl(nav.OuterXml);
        }
    }
}
