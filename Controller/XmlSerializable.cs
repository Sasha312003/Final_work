using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Final_work.Controller
{
    public class XmlSerializable : ISaver
    {
        /// <summary>
        /// реалізація метода Load інтерфейсу ISaver з використанням XML серіалізації
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Загруженні данні</returns>
        public List<T> Load<T>() where T : class 
        {
            var formatter = new XmlSerializer(typeof(List<T>));
            var filePath = typeof(T).Name; // файл буде називатися як клас
            List<T>? list;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    list = formatter.Deserialize(fs) as List<T>;
                }
                catch // якщо файл пустий
                {
                    list = new List<T>();
                }   
            }
            if (list is null)
            {
                list = new List<T>();
            }
            return list;
        }

        /// <summary>
        /// реалізація метода Save інтерфейсу ISaver з використанням XML серіалізації
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Save<T>(List<T> list) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            var filePath = typeof(T).Name;// файл буде називатися як клас

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
