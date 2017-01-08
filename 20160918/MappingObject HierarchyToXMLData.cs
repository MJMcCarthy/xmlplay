using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _XMLStudies
{
    //https://msdn.microsoft.com/en-us/library/a3bszkbd(v=vs.110).aspx
    class MappingObject_HierarchyToXMLData
    {
        //private const String filename = "MappingObjectHierarchyToXMLData.xml";
        private const string path = "../../"; //@"D:\play\XML_XSLT_XPATH\20160918\20160918\";
        private const String default_filename = "MappingObjectHierarchyToXMLData.xml";

        public static void Execute(string filename)
        {
            XmlTextReader reader = null;

            try
            {
                // Load the reader with the data file and ignore 
                // all white space nodes.
                if (filename.Length == 0) filename = default_filename;
                reader = new XmlTextReader(path + filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Attribute:
                            Console.WriteLine("ATTRIBUTE <?{0} {1}?>", reader.Name, reader.Value);
                            break;

                        case XmlNodeType.Element:
                            Console.WriteLine("ELEMENT => <{0}>", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine("TEXT => </{0}>", reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            Console.WriteLine("CDATA =>  <![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            Console.WriteLine("PI  => <?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.WriteLine("COMMENT  => <!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            Console.WriteLine("XMLDECLARATION  => <?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            Console.WriteLine("DOCUMENT => {0}", reader.Value);
                            break;
                        case XmlNodeType.DocumentType:
                            Console.WriteLine("DOCUMENT TYPE => <!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            Console.WriteLine("EntityRerference => {0}", reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine("EndElement => </{0}>", reader.Name);
                            break;
                    }

                    if (reader.AttributeCount > 0)
                    {
                        Console.WriteLine("****************** Attributes start ******************************");
                        for (int attInd = 0; attInd < reader.AttributeCount; attInd++)
                        {
                            reader.MoveToAttribute(attInd);
                            Console.WriteLine(" {0} {1}", reader.Name, reader.Value);
                        }
                        Console.WriteLine("****************** Attributes end ******************************");
                    }

                    Console.WriteLine();
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

    }
}
