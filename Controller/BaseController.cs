using System.Collections.Generic;


namespace Final_work.Controller
{
    public abstract class BaseController
    {
        private readonly ISaver Saver = new XmlSerializable(); // вибір способу збереження данних

        protected List<T> Load<T>() where T : class
        {
            return Saver.Load<T>();
        }

        protected void Save<T>(List<T> list) where T : class
        {
            Saver.Save<T>(list);
        }
    }
}
