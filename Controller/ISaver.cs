using System.Collections.Generic;

namespace Final_work.Controller
{
    public interface ISaver
    {
        List<T> Load<T>() where T : class; // шаблон дженерік метода загрузки данних
        void Save<T>(List<T> list) where T : class; // шаблон дженерік  метода збереження даних
    }
}
