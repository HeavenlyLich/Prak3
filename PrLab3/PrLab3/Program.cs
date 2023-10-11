using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class MyObject
{
    public int Number { get; set; }
    public string Shevchenko { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        MyObject obj = new MyObject
        {

            Number = 1,
            Shevchenko = "Садок вишневий коло хати,\nХрущі над вишнями гудуть.\nПлугатарі з плугами йдуть,\nСпівають, ідучи, дівчата,\nА матері вечерять ждуть.\n\nСім’я вечеря коло хати,\nВечірня зіронька встає.\nДочка вечерять подає,\nА мати хоче научати,\nТак соловейко не дає.\n\nПоклала мати коло хати\nМаленьких діточок своїх,\nСама заснула коло їх.\nЗатихло все, тілько дівчата\nТа соловейко не затих."
        };

        // Серіалізація в XML
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyObject));
        using (StreamWriter xmlWriter = new StreamWriter("object.xml"))
        {
            xmlSerializer.Serialize(xmlWriter, obj);
        }

        // Десеріалізація з XML
        using (StreamReader xmlReader = new StreamReader("object.xml"))
        {
            MyObject deserializedFromXml = (MyObject)xmlSerializer.Deserialize(xmlReader);
            Console.WriteLine($"{deserializedFromXml.Number}\n{deserializedFromXml.Shevchenko}");
        }
    }
}
