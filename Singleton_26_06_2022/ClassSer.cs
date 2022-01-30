using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Singleton_26_06_2022
{
    public static class ClassSer
    {
        public static void toXML<T>(ref T inObject, String inFileName)
        {
            StreamWriter file = new StreamWriter(inFileName);
            try
            {
                XmlSerializer writter = new XmlSerializer(typeof(T));
                writter.Serialize(file, inObject);
            }
            catch (Exception exc) { Console.WriteLine("Serialization error"); }
            finally { file.Close(); }
        }
        public static void fromXML<T>(ref T inObject, String inFileName)
        {
            if (File.Exists(inFileName))
            {
                StreamReader file = new StreamReader(inFileName);
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(T));
                    inObject = (T)reader.Deserialize(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Serialization error");
                }
                finally { file.Close(); }
            }
            else MessageBox.Show("File doesn`t exist: " + inFileName);
        }
    }
}
