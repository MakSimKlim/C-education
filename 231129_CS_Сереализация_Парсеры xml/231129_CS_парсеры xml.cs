using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// ТЭГИ для xml  документации:
/// <summary>
/// это подсказка для этого метода
/// </summary>
/// <param>
/// <paramref>
/// <returns></returns>
/// <remarks></remarks>
/// <example></example>
/// <c></c>
/// <code></code>
/// <see cref="Person"/>
/// <exception>


namespace _231129_CS_парсеры_xml
{
    /// <summary>
    /// The <c> Distance </c> class provides methods to convert
    /// kilometers to miles and back
    /// </summary>
    public class Distance
    {
        /// <summary>
        /// Converts kilometers to miles
        /// </summary>
        /// <param name="kilometres">
        /// Use to indicate kilometres. A <see cref="double"/> type
        /// representating the value
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <paramref name = "kilometres"/> is negative
        /// </exception>
        /// <returns>
        /// </returns>
        public static double KilometresToMiles(double kilometres)
        {
            if (kilometres < 0)
                throw new ArgumentException("Должно быть положительным");
            return kilometres * 0.621371;


        }
        public static double KMilesToMiles(double miles)
        {
            if (miles < 0)
                throw new ArgumentException("Должно быть положительным");
            return miles * 1.1256;


        }
    }
    
    class Program
    {
        
        static void WithWriters()
        {
            //XmlReader
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("Cars.xml",
                    System.Text.Encoding.Unicode);
                writer.Indentation = 4;
                writer.IndentChar = '\t';

                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");
                writer.WriteAttributeString("Image", "MyCar.jpg");
                writer.WriteElementString("Made", "Italy");
                writer.WriteElementString("Model", "Lamborgini");
                writer.WriteElementString("Year", "1999");
                writer.WriteElementString("Color", "Red");
                writer.WriteElementString("Speed", "300");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                Console.WriteLine("");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

            }

        }


        static void ReadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Cars.xml");
                OutputNode(doc.DocumentElement);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        static void Bikes()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Cars.xml");

                XmlNode root = doc.DocumentElement;
                root.RemoveChild(root.FirstChild);
                XmlNode bike = doc.CreateElement("Motorcycle");
                XmlNode made = doc.CreateElement("Made");
                XmlNode model = doc.CreateElement("Model");
                XmlNode year = doc.CreateElement("Year");
                XmlNode color = doc.CreateElement("Color");
                XmlNode textMade = doc.CreateElement("Usa");
                XmlNode textModel = doc.CreateTextNode("1920");
                XmlNode textYear = doc.CreateTextNode("Harley 20J");
                XmlNode textColor = doc.CreateTextNode("Olive");
                model.AppendChild(textModel);
                year.AppendChild(textYear);
                color.AppendChild(textColor);
                made.AppendChild(textMade);
                bike.AppendChild(model);
                bike.AppendChild(made);
                bike.AppendChild(year);
                bike.AppendChild(color);
                root.AppendChild(bike);
                doc.Save("Motorcycles.xml");

                WriteLine("Motorcycles.xml was generate");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
           
        }

        static void XmlReaderStuff()
        {
            XmlTextReader xmlReader = null;
            try
            {
                xmlReader = new XmlTextReader("Cars.xml");
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                while (xmlReader.Read())
                {
                    WriteLine($"Type={xmlReader.NodeType}\t" +
                     $"Name = {xmlReader.Name}\t" +
                     $"Value = {xmlReader.Value}\t");
                    if (xmlReader.Read())
                    {
                        WriteLine($"Type={xmlReader.NodeType}\t" +
                         $"Name = {xmlReader.Name}\t" +
                         $"Value = {xmlReader.Value}\t");

                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
            }

        }

        static void OutputNode(XmlNode node)
        {
            WriteLine($"Type = {node.NodeType}\tName={node.Name}\t" +
                $"Value={node.Value}");

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    WriteLine($"Type = {attr.NodeType}\tName={attr.Name}\t" +
                   $"Value={attr.Value}");
                }
            
            }

            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    OutputNode(child);
                }
            } 
        }

        static void XmlTextReaderAttributes()
        {
            XmlTextReader xmlReader = null;
            try
            {
                xmlReader = new XmlTextReader("Cars.xml");
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element &&
                        xmlReader.Name == "Car" && xmlReader.AttributeCount > 0)
                    {
                        while (xmlReader.MoveToNextAttribute())
                        {
                            if (xmlReader.Name == "Image.jpg")
                            {
                                //...
                            }

                        }

                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
            }
        }



        static void Main(string[] args)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("Books.xml",
                    System.Text.Encoding.Unicode);
                writer.Indentation = 4;
                writer.IndentChar = '\t';

                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Books");
                writer.WriteStartElement("Book");
                writer.WriteAttributeString("Image", "MyBook.jpg");
                writer.WriteElementString("Author", "Stiven Prata");
                writer.WriteElementString("Name", "Language of Programming C++");
                writer.WriteElementString("Year", "2003");
                writer.WriteElementString("Pages", "350");
                writer.WriteElementString("Language", "Russian");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                Console.WriteLine("");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

            }



        }

    }
}
