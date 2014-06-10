using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace controlPrg
{
    class XML_Worker
    {
        public static void Save_to_xml_file(Type T,object obj, string filename)
        {
            XmlTextWriter xw = new XmlTextWriter(filename, Encoding.UTF8);
            xw.Formatting = Formatting.Indented;
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
            DataContractSerializer ser = new DataContractSerializer(T);
            ser.WriteObject(writer, obj);
            writer.Close();
            xw.Close();
        }
        public static string Save_to_xml_string(Type T, object obj)
        {
            DataContractSerializer ser = new DataContractSerializer(T);
            StringWriter output = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(output);
            ser.WriteObject(writer, obj);
            return output.GetStringBuilder().ToString();
        }
        public static object Read_from_xml(Type T, string filename)
        {
            object obj = Activator.CreateInstance(T);
            var path = filename;
            XmlTextReader xr = new XmlTextReader(path);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(xr);
            DataContractSerializer ser = new DataContractSerializer(T);
            obj = ser.ReadObject(reader);
            reader.Close();
            xr.Close();
            return obj;
        }
        public static object Read_from_string(Type T, string str)
        {
            object obj = Activator.CreateInstance(T);
            DataContractSerializer ser = new DataContractSerializer(T);
            StringReader input = new StringReader(str);
            XmlTextReader reader = new XmlTextReader(input);
            obj = ser.ReadObject(reader);
            reader.Close();
            input.Close();
            return obj;
        }
    }
}
