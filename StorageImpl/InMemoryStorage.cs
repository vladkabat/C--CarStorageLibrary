using System;
using System.Collections.Generic; 

namespace CarStorageLibrary.StorageImpl
{
    class InMemoryStorage : AbstractStorage
    {
        Menu table = new Menu();
        private List<Car> cars;
        int id = 0;

        private static InMemoryStorage instance;

        public static InMemoryStorage Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new InMemoryStorage();
                }
                return instance;
            }
        }

        private InMemoryStorage()
        {
            cars = new List<Car>();
        }
        
        protected override List<Car> Load()
        {
            return cars;
        }


        public override bool OutputElements()
        {
            if (Load().Count > 0)
            {
                table.HeadTable();
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
            table.FooterTable();
                return true;
            }
            else return false;
        }

        public override bool Get(int id)
        {
            if (GetId(id) != null)
            {
                table.HeadTable();
                foreach (Car car in cars)
                {
                    if (car.Id == id)
                        Console.WriteLine(car);
                }

                table.FooterTable();
                return true;
            }
            else
                return false;
        }

        public override bool Filtration(int i, object name)
        {
            if (FiltrationRealis(i, name) != null)
            {
                table.HeadTable();
                foreach (Car car in FiltrationRealis(i, name))
                    Console.WriteLine(car);
                table.FooterTable();
                return true;
            }
            else return false;
        }

        public override void Save()
        { 
        }

        public override int GetEndId()
        {
            if (Load().Count != 0)
                id = cars[cars.Count - 1].Id;
            return id;
        }

        public override string ToString()
        {
            string repositroy = "++++++++++++++++++++++++++++++\n";
            repositroy += "+ Работа через консоль\n";
            repositroy += "++++++++++++++++++++++++++++++\n";
            return repositroy;
        }
    }
}
