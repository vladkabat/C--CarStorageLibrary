using System;

namespace CarStorageLibrary
{
    class Menu
    {
        public void HeadTable()
        {
            Console.WriteLine("                      Автомобили                  ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Марка | Мощность | Стоимость | Окраска | Номер |");
            Console.WriteLine("--------------------------------------------------");
        }
        public void FooterTable()
        {
            Console.WriteLine("--------------------------------------------------");
        }
        public void FileRespository()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| 1 - Работать через консоль;                        |");
            Console.WriteLine("| 2 - Работать через текстовый файл;                 |");
            Console.WriteLine("| 3 - Работать через бинарный файл.                  |");
            Console.WriteLine("------------------------------------------------------\n");
        }
        public void AllMethodsMenu()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| 1 - Добавление элемента в список;                  |");
            Console.WriteLine("| 2 - Вывод всего списка;                            |");
            Console.WriteLine("| 3 - Вывод элемента списка по номеру;               |");
            Console.WriteLine("| 4 - Получить дату последнего изменения;            |");
            Console.WriteLine("| 5 - Удалить элемент списка по номеру;              |");
            Console.WriteLine("| 6 - Cортировка по выбранному полю;                 |");
            Console.WriteLine("| 7 - Фильтрация по выбранному полю;                 |");
            Console.WriteLine("| 8 - Изменить запись по выбранному полю;            |");
            Console.WriteLine("| 9 - Работать другим способом;                      |");
            Console.WriteLine("| 10 - Создать новый файл;                           |");
            Console.WriteLine("| 11 - Удалить файл;                                 |");
            Console.WriteLine("| 12 - Выход.                                        |");
            Console.WriteLine("------------------------------------------------------\n");
        }

        public void BuildFile()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| 1 - Создать текстовый файл;                        |");
            Console.WriteLine("| 2 - Создать бинарный файл.                         |");
            Console.WriteLine("------------------------------------------------------\n");
        }

        public void DeleteMenu()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| 1 - Удалить текстовый файл;                        |");
            Console.WriteLine("| 2 - Удалить бинарный файл.                         |");
            Console.WriteLine("------------------------------------------------------\n");
        }

        public void ChangeElement()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| 1 - Марка машины;                                  |");
            Console.WriteLine("| 2 - Мощность машины;                               |");
            Console.WriteLine("| 3 - Стоимость машины;                              |");
            Console.WriteLine("| 4 - Цвет машины;                                   |");
            Console.WriteLine("------------------------------------------------------\n");
        }
    }
}
