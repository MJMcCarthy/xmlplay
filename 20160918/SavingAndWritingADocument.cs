using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    class SavingAndWritingADocument
    {
        public static void Execute()
        {
            Console.WriteLine("Opening books.xml and saving as out.xml");
            XmlDocument doc = new XmlDocument();

            //https://blogs.msdn.microsoft.com/xmlteam/2011/10/08/the-world-has-moved-on-have-you-xml-apis-you-should-avoid-using/
            //shouldn't use XmlTextWriter any longer
            //XmlTextWriter tw = new XmlTextWriter(@"D:\play\XML_XSLT_XPATH\20160918\20160918\out.xml", null);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            XmlWriter tw = XmlWriter.Create("../../out.xml");

            doc.Load("../../books.xml");
            doc.Save(tw);

            Console.WriteLine("Set OuterXML of books.xml to a string. Display string in console");
            Console.WriteLine("");
            string booksXML = doc.OuterXml;
            Console.Write(booksXML);

            Console.WriteLine("");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Set InnerText of books.xml to a string. Display string in console");
            Console.WriteLine("*******************************************************");
            booksXML = doc.InnerText;
            Console.Write(booksXML);

        }
    }
}

