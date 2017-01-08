using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Compiled_XPath_Expressions
    {
        public static void Execute()
        {
            U.header("Compiled_XPath_Expressions");

            //this runs against the entire xml.
            Console.WriteLine("this runs against the entire xml.");
            XPathDocument doc = new XPathDocument("../../../XMLs/books.xml");
            XPathNavigator nav = doc.CreateNavigator();

            string queryStr = "sum(descendant::book/price)";
            //XPathExpression query = nav.Compile("sum(descendant::book/price");
            XPathExpression query = nav.Compile(queryStr);

            Double total = (double)nav.Evaluate(query);
            Console.WriteLine("Total price for all books evaluate via {0}, is {1}", queryStr, total);


            //this one uses only book nodes!
            Console.WriteLine("this one uses only book nodes!");
            XPathNavigator navBoooks = doc.CreateNavigator();

            XPathNodeIterator books = nav.Select("//book");
            string queryStrBooks = "sum(descendant::price)";
            //XPathExpression queryBooks = books.Current.Compile("Sum(descendant::price)");
            XPathExpression queryBooks = books.Current.Compile(queryStrBooks);

            Double totalBooks = (double)nav.Evaluate(queryBooks, books);
            Console.WriteLine("Total price for all books evaluate via {0}, is {1}", queryStrBooks, totalBooks);

            Console.WriteLine("Do the 2 attempts match? I hope so!");

        }
    }
}

