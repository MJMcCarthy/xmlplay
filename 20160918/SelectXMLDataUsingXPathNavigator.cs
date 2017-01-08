using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace _XMLStudies
{
    class SelectXMLDataUsingXPathNavigator
    {
        public static void Execute()
        {
            Console.WriteLine("SelectXMLDataUsingXPathNavigator");

            XPathDocument doc = new XPathDocument("../../books1.xml");
            XPathNavigator navigator = doc.CreateNavigator();

            Console.WriteLine("Books bookstore/book");
            XPathNodeIterator nodes = navigator.Select("bookstore/book");
            while (nodes.MoveNext())
            {
                Console.WriteLine("{0} {1} {2}", nodes.Current.Name, nodes.Current.Value, nodes.Current.InnerXml);
            }

            Console.WriteLine("inventory.xml last-name find-ancestors");
            XPathDocument docInventory = new XPathDocument("../../inventory.xml");
            XPathNavigator navigatorInventory = docInventory.CreateNavigator();
            nodes = navigatorInventory.Select("//last-name");
            Console.WriteLine("inventory.xml last-name");
            while (nodes.MoveNext())
            {
                Console.WriteLine("{0} {1} {2}", nodes.Current.Name, nodes.Current.Value, nodes.Current.InnerXml);
            }

            navigatorInventory.MoveToChild("bookstore", "");
            //navigatorInventory.MoveToChild("book", "");
            XPathNodeIterator bookDescendants = navigatorInventory.SelectDescendants("last-name", "", false);

            Console.WriteLine("inventory.xml last-name with SelectDescendants ********************");
            while (bookDescendants.MoveNext())
            {
                Console.WriteLine("{0} {1} {2}", bookDescendants.Current.Name, bookDescendants.Current.Value, bookDescendants.Current.InnerXml);
            }

            Console.WriteLine("inventory.xml last-name with SelectDescendants & then SelectAncestores ********************");
            bookDescendants = navigatorInventory.SelectDescendants("last-name", "", false);
            int index = 0;
            while (bookDescendants.MoveNext())
            {
                Console.WriteLine("Descendant {0} $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$", index++);
                Console.WriteLine("{0} {1} ", bookDescendants.Current.Name, bookDescendants.Current.Value);
                XPathNodeIterator ancestors = bookDescendants.Current.SelectAncestors("", "", true);
                while (ancestors.MoveNext())
                {
                    Console.WriteLine("{0} {1} ", ancestors.Current.Name, ancestors.Current.Value);
                }
            }

            //Evaluate XPath Expressions using XPathNavigator
            navigator = doc.CreateNavigator();

            XPathExpression query = navigator.Compile("sum(//price/text())");
            Double total = (Double)navigator.Evaluate(query);
            Console.WriteLine(total);

            //XmlNodeList styles = docInventory.Select("//book/@genre");

            bool novelExists = (bool)navigator.Evaluate(query);
            Console.WriteLine("There is a novel = {0}", novelExists.ToString());

        }

    }
}
