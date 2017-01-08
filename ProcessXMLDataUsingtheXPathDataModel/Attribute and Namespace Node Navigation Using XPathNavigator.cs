using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Attribute_and_Namespace_Node_Navigation_Using_XPathNavigator
    {
        public static void Execute()
        {
            U.header("Node_Set_Navigation_Using_XPathNavigator");

            string xml = "../../../XMLs/contosoBooks.xml";
            //XPathDocument document = new XPathDocument("../../../XMLs/contosoBooks.xml");
            XPathDocument document = new XPathDocument(xml);
            XPathNavigator navigator = document.CreateNavigator();

            //move to bookstore
            navigator.MoveToFirstChild();

            //bool moveResult = false;

            //navigator.MoveToRoot();
            navigator.MoveToChild("book", "http://www.contoso.com/books");
            //while (navigator.MoveToChild("book", "http://www.contoso.com/books"))
            do{
                Console.WriteLine("navigator.MoveToFirstChild() navigator.name: {0}", navigator.Name);
                Console.WriteLine(navigator.OuterXml);

                XPathNavigator navAttr = navigator.Clone();

                //moveResult = navigator.MoveToFirstAttribute();
                if (navAttr.MoveToFirstAttribute())
                {
                    Console.WriteLine("navAttr.MoveToFirstAttribute() navigator.name: {0}", navAttr.Name);
                    Console.WriteLine("{0} = {1}", navAttr.Name, navAttr.Value);

                    while (navAttr.MoveToNextAttribute())
                    {
                        Console.WriteLine("navAttr.MoveToNextAttribute() navigator.name: {0}", navAttr.Name);
                        Console.WriteLine("{0} = {1}", navAttr.Name, navAttr.Value);
                    }
                }
                Console.WriteLine();
            } while (navigator.MoveToNext());

        }
    }
}
