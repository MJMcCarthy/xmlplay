using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class XPath_Context
    {
        public static void Execute()
        {
            U.header("XPath_Context");
            U.wl("Look at same XPath predicate with different contexts");

            string[] searches = new string [] {"./book", "./*", "*", ".//*", 
                "ancestor::*", "ancestor-or-self::*","child::*", "descendant::*", "attribute::*",
                "following::*", "following-sibling::*", 
                "preceding::*", "preceding-sibling::*"};

            foreach(string search in searches)
            {
                U.header("Search is " +  search);

                XPathDocument doc = new XPathDocument("../../../XMLs/books.xml");
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator nodes;

                U.wl("context root");
                nav.MoveToRoot();
                nodes = nav.Select(search);
                U.wl(nodes.Count.ToString());

                U.wl("bookstore ");
                nav.MoveToChild("bookstore", "");
                nodes = nav.Select(search);
                U.wl(nodes.Count.ToString());

                U.wl("book MoveToFirstChild()");
                nav.MoveToFirstChild();
                nodes = nav.Select(search);
                U.wl(nodes.Count.ToString());

                U.wl("book MoveToNext()");
                nav.MoveToNext();
                nodes = nav.Select(search);
                U.wl(nodes.Count.ToString());

                U.wl("book MoveToNext() again! Does Count decrement?");
                nav.MoveToNext();
                nodes = nav.Select(search);
                U.wl(nodes.Count.ToString());
            }
        }

        


    }
}
