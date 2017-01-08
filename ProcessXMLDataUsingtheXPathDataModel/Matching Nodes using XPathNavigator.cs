using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Matching_Nodes_using_XPathNavigator
    {
       public static void Execute()
        {
            U.header("Matching_Nodes_using_XPathNavigator");

            //*************************************************
            //XPathDocument
            //*************************************************
            Console.WriteLine("New XPathDocument");
            XPathDocument xpathdoc = new XPathDocument("../../../XMLs/books.xml");

            XPathNavigator nav = xpathdoc.CreateNavigator();

            //select all book nodes
            XPathNodeIterator nodes = nav.SelectDescendants("book", "", false);

            //Select all book nodes that have the matching attribute value
            XPathExpression expr = nav.Compile("book[genre='Fantasy']");

            //we'll use MATCH here
            Console.WriteLine("We are using MATCH here");
            Console.WriteLine("*************************************************");
            while (nodes.MoveNext())
            {
                XPathNavigator nav2 = nodes.Current.Clone();
                if (nav2.Matches(expr))
                {
                    nav2.MoveToChild("title", "");
                    Console.WriteLine("Book title: {0}", nav2.Value);
                }
            }

            //let's try it again another way with Evaluate
            Console.WriteLine();
            Console.WriteLine("let's try it again another way with EVALUATE");
            Console.WriteLine("*************************************************");
            XPathNodeIterator fantasies = (XPathNodeIterator)nav.Evaluate(expr);
            while(fantasies.MoveNext())
            {
                XPathNavigator fantasy = fantasies.Current.Clone();
                fantasy.MoveToChild("title", "");
                Console.WriteLine("Book title: {0}", fantasy.Value);
            }

            Console.WriteLine("Are MATCH and EVALUATE the same?");
            Console.WriteLine("NOPE! I think the XPathExpression won't work in EVALUATE. Try again");
            U.breaks();


            //let's try it again another way with Evaluate & different XPathExpression
            //Select all book nodes that have the matching attribute value
            XPathExpression expr1 = nav.Compile("/bookstore/book[genre='Fantasy']");
            Console.WriteLine();
            Console.WriteLine("let's try it again another way with EVALUATE & different XPathExpression");
            Console.WriteLine("*************************************************");
            XPathNodeIterator fantasiesAgain = (XPathNodeIterator)nav.Evaluate(expr1);
            while (fantasiesAgain.MoveNext())
            {
                XPathNavigator fantasy = fantasiesAgain.Current.Clone();
                fantasy.MoveToChild("title", "");
                Console.WriteLine("Book title: {0}", fantasy.Value);
            }

            Console.WriteLine("Are MATCH and seond EVALUATE the same?");
            string str = "Yes! And why is this? Look at expr. We have book[genre='Fantasy']. When we are matching this \n against a node that is a book! In the first EVALUATE we will not find anything becausethe XPath finds nothing because the form of it starts at the root. In the second EVALUATE I use  / bookstore / book[genre = 'Fantasy'] so result nodes are found";
            Console.WriteLine(str);
        }

    }
}