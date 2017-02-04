using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CarStorageLibrary.StorageImpl
{
    class BinarryStorage : AbstractStorage
    {
        BinaryWriter sw;
        List<Car> cars;
        string path;
        int id = 0;

        public BinarryStorage(string path)
        {
            cars = new List<Car>();
            this.path = path;
            ReadFile();
            sw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
        }

        protected override List<Car> Load()
        {
            return cars;
        }

        public override bool OutputElements()
        {
            if (Load().Count > 0)
            {
                Save();
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    binFormat.Serialize(fStream, cars);
                }
            }
            catch (IOException)
            {
            }
            sw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                return true;
            }
            else return false;
        }

        public override bool Get(int id)
        {
            if (GetId(id) != null)
            {
                Save();
                BinaryFormatter binFormat = new BinaryFormatter();
                try
                {
                    using (Stream fStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        foreach(Car car in cars)
                        {
                            if(car.Id == id)
                                binFormat.Serialize(fStream, car);
                        }
                    }
                }
                catch (IOException)
                {
                }
                sw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                return true;
            }
            else
                return false;
        }

        public override bool Filtration(int i, object name)
        {
            if (FiltrationRealis(i, name) != null)
            {
                Save();
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    binFormat.Serialize(fStream, FiltrationRealis(i, name));
                }
            }
            catch (IOException)
            {
            }
            sw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            return true;
            }
            else return false;
        }

        public override void Save()
        {
            sw.Close();
        }

        public void ReadFile()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    
                        var myCar = (List<Car>)binFormat.Deserialize(stream);
                        foreach (Car j in myCar)
                        {
                            cars.Add(new Car(j.Mark, j.Power, j.Prise, j.Color, j.Id));
                        }
                    }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
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
            repositroy += "+ Работа через бинарный файл\n";
            repositroy += "++++++++++++++++++++++++++++++\n";
            return repositroy;
        }
    }
}
