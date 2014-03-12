using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SocialHeatMap.DataServices
{
    public static class SerializeUtility<T>
    {
        public static XElement SerializeObject(T item)
        {
            XDocument target = new XDocument();
            XmlSerializer s = new XmlSerializer(typeof(T));
            XmlWriter writer = target.CreateWriter();
            s.Serialize(writer, item);
            writer.Close();

            return target.Root;
        }

        public static T DeserializeObject(string xml)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            UTF8Encoding encoding = new UTF8Encoding();
            MemoryStream stream = new MemoryStream(encoding.GetBytes(xml));
            XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);

            //Return the object
            return (T)s.Deserialize(stream);
        }
    }
}
