using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    class CreateNewNodesInTheDOM
    {
        public static void Execute()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../books.xml");

            XmlNode bookstore = doc.SelectSingleNode("bookstore");

            XmlNodeList books = doc.SelectNodes("//book"); //this works
            books = doc.SelectNodes("book"); //nope!
            books = doc.SelectNodes("/book"); //nope! This is looking for books at root
            books = doc.SelectNodes("./book"); //CURRENT CONTEXT is ./ but this still doesn't work
            books = bookstore.SelectNodes("books");//nope
            books = bookstore.SelectNodes("./book"); //OK this worked and got 12 books

            foreach (XmlNode book in books)
            {
                Console.WriteLine("insert comments before the book node");
                // Create an attribute collection from the element.
                XmlAttributeCollection attrColl = book.Attributes;

                XmlComment newComment;
                newComment = doc.CreateComment(attrColl[0].Name + " " + attrColl[0].Value);
                bookstore.InsertBefore(newComment, book);

                Console.WriteLine("add attribute to the book node");
                //XmlAttribute attr = new XmlAttribute(); no access to this per MSDN
                XmlNode genre = book.SelectSingleNode("./genre");

                XmlAttribute attr = doc.CreateAttribute("genre");
                attr.Value = genre.InnerText;
                attrColl.Append(attr);                
            }

            //save
            Console.WriteLine("save the doc to a file CreateNewNodesInTheDOM.xml");
            doc.Save("../../CreateNewNodesInTheDOM_insert_before.xml");
        }
    }
}
