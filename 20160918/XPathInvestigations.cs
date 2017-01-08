using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    class XPathInvestigations
    {
        public static void Execute()
        {
            XmlDocument doc = new XmlDocument();
            Console.WriteLine("Load inventory.xml");
            doc.Load("../../inventory.xml");

            //XmlNode bookstore = doc.SelectSingleNode("bookstore");
            //XmlNodeList books = doc.SelectNodes("//book");
            //foreach (XmlNode book in books)

            //hoping to get all child elements of books
            //Console.WriteLine("Current context attributes //book/*");
            //XmlNodeList childElementsBooks = doc.SelectNodes("//book/*");
            Console.WriteLine("Current context attributes /bookstore/book/*");
            XmlNodeList childElementsBooks = doc.SelectNodes("./bookstore/book/*");
            foreach (XmlNode childElement in childElementsBooks)
            {
                //Console.WriteLine("Parent node name {0} {1}",
                    //childElement.ParentNode.Name, childElement.ParentNode.SelectSingleNode("//title").InnerText); //all titles
                    //childElement.ParentNode.Name, childElement.ParentNode.SelectSingleNode("/title").InnerText); //no good blows up
                Console.WriteLine("childElement name={0}   childElement value={1} innerText={2}"
                    , childElement.Name, childElement.Value, childElement.InnerText);

            }

            //just prices
            Console.WriteLine("just prices");
            XmlNodeList prices = doc.SelectNodes("/bookstore/book/price");
            foreach (XmlNode price in prices)
            {
                Console.WriteLine("price {0}   "
                    , price.InnerText);

            }

            //current context - we are at the root
            Console.WriteLine("Current context ******************************************");
            Console.WriteLine("Current context .//authors");
            XmlNode bookstore = doc.SelectSingleNode("bookstore");
            XmlNodeList authors = bookstore.SelectNodes("./book/author");
            foreach(XmlNode author in authors)
            {
                Console.WriteLine("First Name {0}   Surname {1}", author.FirstChild.InnerText, author.FirstChild.NextSibling.InnerText);
            }

            Console.WriteLine("Current context //authors");
            authors = doc.SelectNodes("//author");
            foreach (XmlNode author in authors)
            {
                Console.WriteLine("First Name {0}   Surname {1}", author.FirstChild.InnerText, author.FirstChild.NextSibling.InnerText);
            }

            Console.WriteLine("Current context attributes ./book/@style");
            XmlNodeList styles = bookstore.SelectNodes("./book/@style");
            foreach (XmlNode style in styles)
            {
                Console.WriteLine("Style name {0}   Style value {1}", style.Name, style.Value);
            }

            Console.WriteLine("Current context attributes first book //bookstore/book");
            XmlNode firstBook = doc.SelectSingleNode("//bookstore/book");
            XmlNodeList authorFirstNames = firstBook.SelectNodes("./author/first-name");
            foreach (XmlNode authorFirstName in authorFirstNames)
            {
                Console.WriteLine("authorFirstName name {0}   authorFirstName value {1} InnerText {2}", 
                    authorFirstName.Name, authorFirstName.Value, authorFirstName.InnerText);
            }

            Console.WriteLine("Current context attributes first book //bookstore");
            XmlNode bookStore = doc.SelectSingleNode("//bookstore");
            authorFirstNames = bookStore.SelectNodes(".//author/first-name");
            foreach (XmlNode authorFirstName in authorFirstNames)
            {
                Console.WriteLine("authorFirstName name {0}   authorFirstName value {1} InnerText {2}",
                    authorFirstName.Name, authorFirstName.Value, authorFirstName.InnerText);
            }

            Console.WriteLine("Current context attributes first book /bookstore");
            bookStore = doc.SelectSingleNode("/bookstore");
            authorFirstNames = bookStore.SelectNodes("book/author/first-name");
            foreach (XmlNode authorFirstName in authorFirstNames)
            {
                Console.WriteLine("authorFirstName name {0}   authorFirstName value {1} InnerText {2}",
                    authorFirstName.Name, authorFirstName.Value, authorFirstName.InnerText);
            }

            Console.WriteLine("Current context attributes first book bookstore");
            bookStore = doc.SelectSingleNode("bookstore");
            authorFirstNames = bookStore.SelectNodes("book/author/first-name");
            foreach (XmlNode authorFirstName in authorFirstNames)
            {
                Console.WriteLine("authorFirstName name {0}   authorFirstName value {1} InnerText {2}",
                    authorFirstName.Name, authorFirstName.Value, authorFirstName.InnerText);
            }

            //end of current context
            Console.WriteLine("end of current context ****************************");
            Console.WriteLine("");

            Console.WriteLine("book attributes");
            XmlNodeList books = bookStore.SelectNodes("book");
            foreach(XmlNode book in books)
            {
                Console.WriteLine("{0}", book.Name);
                XmlNodeList attributes = book.SelectNodes("@*");
                foreach(XmlNode attr in attributes)
                {
                    Console.WriteLine("attribute name {0}   attribute value {1}", attr.Name, attr.Value);
                }
            }

            Console.WriteLine("author[(degree or award) and publication]");
            authors = bookStore.SelectNodes("//author[(degree or award) and publication]");
            foreach (XmlNode author in authors)
            {
                Console.WriteLine("{0}", author.InnerText);
            }

            Console.WriteLine("author/degree[text()='B.A']");
            //authors = bookStore.SelectNodes("//author/degree[text()='B.A']");
            //authors = bookStore.SelectNodes("//author/degree");
            XmlNodeList degrees = bookStore.SelectNodes("//author/degree[text()='B.A.']");
            foreach (XmlNode degree in degrees)
            {
                XmlNode author = degree.SelectSingleNode("..");
                Console.WriteLine("{0}", author.InnerText);
            }

            Console.WriteLine("price < 10");
            books = bookStore.SelectNodes("book[price < 10]");
            foreach (XmlNode book in books)
            {
                XmlNode title = book.SelectSingleNode("title");
                Console.WriteLine("{0}", title.InnerText);
            }

            Console.WriteLine("price < 10 redux");
            XmlNodeList titles = bookStore.SelectNodes("book[price < 10]/title");
            foreach (XmlNode title in titles)
            {
                Console.WriteLine("{0}", title.InnerText);
            }

            Console.WriteLine("all attributes?");
            XmlNodeList attributesList = bookStore.SelectNodes("//@*");
            foreach (XmlNode attribute in attributesList)
            {
                Console.WriteLine("{0} {1}", attribute.Name, attribute.Value);
            }

            Console.WriteLine("Node-Set Functions");
            books = bookStore.SelectNodes("book");
            Console.WriteLine("{0} ", books.Count);
            int index = 0;
            foreach (XmlNode book in books)
            {
                XmlNode title = book.SelectSingleNode("title");
                Console.WriteLine("{0} {1}", title.InnerText, books.Item(index++));
            }



        }
    }
}
