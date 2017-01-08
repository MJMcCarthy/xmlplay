using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    class RemovingNodesFromTheDOM
    {
        public static void Execute()
        {
            Console.WriteLine("Price is a child node of book. \nAdd it as an attribute to book. \nThen remove it a child node.");
            XmlDocument doc = new XmlDocument();
            doc.Load("../../CreateNewNodesInTheDOM_insert_before.xml");

            XmlNode bookstore = doc.SelectSingleNode("bookstore");

            XmlNodeList books = bookstore.SelectNodes("./book");

            foreach(XmlNode book in books)
            {
                Console.WriteLine("add attribute price to the book node");
                XmlNode price = book.SelectSingleNode("./price");

                XmlAttributeCollection attrColl = book.Attributes;
                XmlAttribute attr = doc.CreateAttribute("price");
                attr.Value = price.InnerText;
                attrColl.Append(attr);

                Console.WriteLine("remove price as child node of book node");                
                //book.RemoveChild(book.SelectSingleNode("./price"));
                book.RemoveChild(price);
                Console.WriteLine("{0} is value for Price attribute.\n{1} is value for Price child node",
                    attrColl["price"].InnerText, price.InnerText);
            }

            //save
            Console.WriteLine("save the doc to a file RemovingNodesAndAddingAttributeFromTheDOM_price.xml");
            doc.Save("../../RemovingNodesAndAddingAttributeFromTheDOM_price.xml");
        }
    }
}
