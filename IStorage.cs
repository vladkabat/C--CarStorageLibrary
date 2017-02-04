using System.Collections.Generic;

namespace CarStorageLibrary
{
    interface IStorage
    {
        // i - выбираем поле
        string UpdateDateChange();
        int GetEndId();
        bool OutputElements();
        bool Get(int id);
        bool Delete(int id);
        // name - Ввдеите поле, которую вы хотите вывести
        bool Filtration(int i, object name);
        bool Sort(int i);
        //передаем ид элемента,который будет изменен,,  otherName - передаем измененное поле
        bool Update(int id, int i, object otherName);
        bool AddNewElement(Car car);
        void Save();
    }
}
