using System;
using System.IO;

namespace CarStorageLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"G:\Курсовая\CarStorageLibrary\CarStorageLibrary\bin\Debug");
            string form = null;
            int idElem = 0;
            Menu menu = new Menu();
            IStorage storage = StorageFactory.CreateMemoryStorage();
            menu.FileRespository();
            Console.WriteLine("Введите номер :");
            int i = InputNumber();
            while (i <= 0 && i > 3)
            {
                i = InputNumber();
            }
            Console.Clear();
            if (i == 2)
                form = "*.csv";
            if (i == 3)
                form = "*.dat";
            storage = NewRepository(storage, i, form, dir);
    

            while (i > 0 && i < 12)
            {
                Console.WriteLine(storage);
                menu.AllMethodsMenu();
                Console.WriteLine("Введите номер :");
                i = InputNumber();
                Console.Clear();

                switch (i)
                {
                    case 1:
                        {
                            bool m = true;
                            int numb;
                            string power = null;
                            string pries = null;
                            idElem = storage.GetEndId();
                            Console.WriteLine("Введите марку машины :");
                            string mark = Console.ReadLine();
                            while (m)
                            {
                                Console.WriteLine("Введите мощность машины :");
                                power = Console.ReadLine();
                                if (int.TryParse(power, out numb))
                                    m = false;
                                else Console.WriteLine("Введен неверный формат данных!");
                            }
                            m = true;
                            while (m)
                            {
                                Console.WriteLine("Введите стоимость машины :");
                                pries = Console.ReadLine();
                                if (int.TryParse(pries, out numb))
                                    m = false;
                                else Console.WriteLine("Введен неверный формат данных!");
                            }
                            Console.WriteLine("Введите цвет машины :");
                            string color = Console.ReadLine();
                            idElem++;
                            Console.Clear();
                            if (storage.AddNewElement(new Car(mark, int.Parse(power), int.Parse(pries), color, idElem)))
                                Console.WriteLine("Элемент добавлен!");
                            else Console.WriteLine("Ошибка при добавлении!");
                        }
                        break;
                    case 2:
                        {
                            if (!storage.OutputElements())
                                Console.WriteLine("Данных еще нет!");
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Введите номер машины :");
                            int id = InputNumber();
                            Console.Clear();
                            if(!storage.Get(id)) Console.WriteLine("Такого элемента нет!");
                        }
                        break;
                    case 4:
                        {
                            if (storage.UpdateDateChange() != null)
                                Console.WriteLine("Дата последнего изменения - {0}\n", storage.UpdateDateChange());
                            else
                                Console.WriteLine("Изменений внесено не было!\n");
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Введите номер машины :");
                            int id = InputNumber();
                            Console.Clear();
                            if (storage.Delete(id))
                                Console.WriteLine("Удаление произошло!");
                            else Console.WriteLine("Ошибка при удалении!\n");
                        }
                        break;
                    case 6:
                        {
                            menu.ChangeElement();
                            Console.WriteLine("Введите номер :");
                            i = InputNumber();
                            Console.Clear();
                            if (storage.Sort(i))
                                Console.WriteLine("Сортировка прошла успешно!");
                            else Console.WriteLine("Ошибка при сортировки!\n");

                        }
                        break;
                    case 7:
                        {
                            menu.ChangeElement();
                            Console.WriteLine("Введите номер :");
                            i = InputNumber();
                            Console.WriteLine("Введите название, по которому будет производиться фильтрация :");
                            string name = Console.ReadLine();
                            Console.Clear();
                            if (storage.Filtration(i, name))
                                Console.WriteLine("Фильтрация прошла успешно!");
                            else Console.WriteLine("Ошибка при фильтрации!");
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("Введите номер машины :");
                            int id = InputNumber();
                            menu.ChangeElement();
                            Console.WriteLine("Введите номер :");
                            i = InputNumber();
                            Console.WriteLine("Введите новое название :");
                            string otherName = Console.ReadLine();
                            Console.Clear();
                            if (storage.Update(id, i, otherName))
                                Console.WriteLine("Обновление произошло!");
                            else Console.WriteLine("Ошибка при обновлении!");
                        }
                        break;
                    case 9:
                        {
                            menu.FileRespository();
                            Console.WriteLine("Введите номер :");
                            i = InputNumber();
                            while (i <= 0 && i > 3)
                            {
                                i = InputNumber();
                            }
                            Console.Clear();
                            if (i == 2)
                                form = "*.csv";
                            if (i == 3)
                                form = "*.dat";
                            storage = NewRepository(storage, i, form, dir);
                            Console.Clear();
                        }
                        break;
                    case 10:
                        {
                            menu.BuildFile();
                            Console.WriteLine("Введите номер :");
                            i = InputNumber();
                            while (i <= 0 && i > 2)
                            {
                                i = InputNumber();
                            }
                            Console.Clear();
                            if (i == 1)
                                form = "*.csv";
                            if (i == 2)
                                form = "*.dat";
                            storage = CreateNewFile(storage,i,form, dir);
                            Console.Clear();
                            
                        }
                        break;
                    case 11:
                        {
                            storage.Save();
                            string s = null;
                            bool m = true;
                            FileInfo[] bmpfiles;
                            Console.WriteLine("Доступны файлы :");
                            if (form == null)
                            {
                                bmpfiles = dir.GetFiles("*.csv");
                                foreach (FileInfo f in bmpfiles)
                                {
                                    Console.WriteLine(f.Name);
                                    s = f.Name;
                                }
                                bmpfiles = dir.GetFiles("*.dat");
                                foreach (FileInfo f in bmpfiles)
                                {
                                    Console.WriteLine(f.Name);
                                    s = f.Name;
                                }
                            }
                            else
                            {
                                bmpfiles = dir.GetFiles(form);
                                foreach (FileInfo f in bmpfiles)
                                {
                                    Console.WriteLine(f.Name);
                                    s = f.Name;
                                }
                            }
                            if (s == null)
                            {
                                Console.WriteLine("Нет доступных файлов");
                                break;
                            }
                            Console.WriteLine("Введите название удаляемого файла :");
                            string path = Console.ReadLine();
                            Console.Clear();
                            while (m)
                                {
                                    foreach (FileInfo f in bmpfiles)
                                    {
                                        if (path == f.Name)
                                        {
                                            m = false;
                                            File.Delete(path);
                                            menu.FileRespository();
                                        Console.WriteLine("Введите номер :");
                                        i = InputNumber();
                                            if (i == 2)
                                                form = "*.csv";
                                            if (i == 3)
                                                form = "*.dat";
                                            storage = NewRepository(storage, i, form, dir);
                                        }
                                    }
                                    if (m == true)
                                    {
                                        Console.WriteLine("Вы ввели неправильно название файла, повторите :");
                                        path = Console.ReadLine();
                                    }
                            }
                        }
                        break;
                    default:
                        {
                            storage.Save();
                        }
                        break;
                }
            }
            Console.ReadKey();
        }

        static int InputNumber()
        {
            string i = null;
            bool m = true;
            int numb;
            while (m)
            {
                i = Console.ReadLine();
                if (int.TryParse(i, out numb))
                    m = false;
                else Console.WriteLine("Введен неверный формат данных!");
            }
            return int.Parse(i);
        }

        static IStorage NewRepository(IStorage storage,int i, string form, DirectoryInfo dir)
        {
            storage.Save();
            string s = null;
            bool m = true;

            if (i == 1)
            {
                storage = StorageFactory.CreateMemoryStorage();
            }
            else
            {
                FileInfo[] bmpfiles = dir.GetFiles(form);
                Console.WriteLine("Доступны файлы :");
                foreach (FileInfo f in bmpfiles)
                {
                    Console.WriteLine(f.Name);
                    s = f.Name;
                }
                if (s == null)
                {
                    Console.WriteLine("Нет доступных файлов");
                    if (i == 2)
                        storage = CreateNewFile(storage, 1, "*.csv", dir);
                    if (i == 3)
                        storage = CreateNewFile(storage, 2, "*.dat", dir);
                }
                else
                {
                    Console.WriteLine("Введите название файла :");
                    string path = Console.ReadLine();
                    while (m)
                    {
                        foreach (FileInfo f in bmpfiles)
                        {
                            if (path == f.Name && i == 2)
                            {
                                m = false;
                                storage = StorageFactory.CreateCsvStorage(path);
                            }
                            if (path == f.Name && i == 3)
                            {
                                m = false;
                                storage = StorageFactory.CreateBinarryStorage(path);
                            }
                        }
                        if (m == true)
                        {
                            Console.WriteLine("Вы ввели неправильно название файла, повторите :");
                            path = Console.ReadLine();
                        }
                    }
                }
            }
            return storage;
        }

        static IStorage CreateNewFile(IStorage storage, int i, string form, DirectoryInfo dir)
        {
            storage.Save();
            FileInfo[] bmpfiles = dir.GetFiles(form);
            bool m = true;
            Console.WriteLine("Введите название файла :");
            string path = Console.ReadLine();
            if (i == 1)
            {
                while (!path.EndsWith(".csv"))
                {
                    Console.WriteLine("Неверный формат файла!");
                    path = Console.ReadLine();
                }
            }
                if (i == 2)
                {
                    while (!path.EndsWith(".dat"))
                    {
                        Console.WriteLine("Неверный формат файла!");
                        path = Console.ReadLine();
                    }
                }
            while (m)
            {
                foreach (FileInfo f in bmpfiles)
                {
                    while(path == f.Name)
                    {
                        Console.WriteLine("Файл с таким названием уже существует, повторите ввод :");
                        path = Console.ReadLine();
                    }
                }
                if (i == 1)
                {
                    m = false;
                    storage = StorageFactory.CreateCsvStorage(path);
                }
                if (i == 2)
                {
                    m = false;
                    storage = StorageFactory.CreateBinarryStorage(path);
                }
            }
            return storage;
        }
    }
}
