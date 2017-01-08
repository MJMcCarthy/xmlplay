using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ProcessXMLDataUsingtheXPathDataModel
{
    class Node_Set_Navigation_Using_XPathNavigator
    {
        public static void Execute()
        {
            U.header("Node_Set_Navigation_Using_XPathNavigator");

            XPathDocument document = new XPathDocument("../../../XMLs/contosoBooks.xml");
            XPathNavigator navigator = document.CreateNavigator();

            bool moveResult = false;

            //https://msdn.microsoft.com/en-us/library/ms163371(v=vs.110).aspx
            moveResult = navigator.MoveToFollowing("price", "http://www.contoso.com/books");

            Console.WriteLine("Position: {0}", navigator.Name);
            Console.WriteLine(navigator.OuterXml);


            //https://msdn.microsoft.com/en-us/library/ms163373(v=vs.110).aspx
            navigator.MoveToRoot();
            moveResult = navigator.MoveToFollowing("book", "http://www.contoso.com/books");
            XPathNavigator boundary = navigator.Clone();
            moveResult = boundary.MoveToFollowing("first-name", "http://www.contoso.com/books");

            moveResult = navigator.MoveToFollowing("price", "http://www.contoso.com/books", boundary); //this is false
            //The original XPathNavigator then attempts to move to the following price element using the MoveToFollowing method with the boundary passed as a parameter.This move fails because the following price element is beyond the boundary. 

            Console.WriteLine("Position (after boundary): {0}", navigator.Name);
            Console.WriteLine(navigator.OuterXml);

            moveResult = navigator.MoveToFollowing("title", "http://www.contoso.com/books", boundary);

            Console.WriteLine("Position (before boundary): {0}", navigator.Name);
            Console.WriteLine(navigator.OuterXml);

            navigator.MoveToRoot();
            moveResult = navigator.MoveToFirstChild();
            Console.WriteLine("Position (before boundary): {0}", navigator.Name);
            Console.WriteLine(navigator.OuterXml);

            moveResult = navigator.MoveToFirstChild();
            Console.WriteLine("Position (before boundary): {0}", navigator.Name);
            Console.WriteLine(navigator.OuterXml);

        }
    }
}
