using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;


namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Evaluate_XPath_Expressions_using_XPathNavigator
    {
        public static void Execute()
        {

            U.header("Evaluate_XPath_Expressions_using_XPathNavigator");

            Console.WriteLine("New XPathDocument");
            XPathDocument xpathdoc = new XPathDocument("../../../XMLs/books.xml");

            XPathNavigator xPathDocNav = xpathdoc.CreateNavigator();

            Console.WriteLine("Let's use Evaluate for XPathNavigator");
            XPathExpression query = xPathDocNav.Compile("sum(//price/text())");
            Double total = (Double)xPathDocNav.Evaluate(query);
            Console.WriteLine("Total of all prices in books.xml is {0}", total);
        }
    }
}
