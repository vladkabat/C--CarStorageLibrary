using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorageLibrary.StorageImpl
{
    class CsvStorage : AbstractStorage
    {
        StreamWriter sw;
        List<Car> cars;
        string path;
        int id = 0;

        public CsvStorage(string path)
        {
            cars = new List<Car>();
            this.path = path;
            ReadFile();
            sw = new StreamWriter(path, false);
        }

        protected override List<Car> Load()
        {
            return cars;
        }


        public override bool OutputElements()
        {
            if (Load().Count > 0)
            {
                foreach (Car j in cars)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4}", j.Mark, j.Power, j.Prise, j.Color, j.Id);
                }
                return true;
            }
            else return false;
        }

        public override bool Get(int id)
        {
            if (GetId(id) != null)
            {
                foreach (Car car in cars)
                {
                    if (car.Id == id)
                        sw.WriteLine(car);
                }
                return true;
            }
            else
                return false;
        }

        public override bool Filtration(int i, object name)
        {
            if (FiltrationRealis(i, name) != null)
            {
                foreach (Car car in FiltrationRealis(i, name))
                sw.WriteLine("{0};{1};{2};{3};{4}", car.Mark, car.Power, car.Prise, car.Color, car.Id);
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
            string[] elem = new string[5];
            int ind = 0;
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (true)
                    {
                        string st = sr.ReadLine();
                        if (st == null)
                        {
                            break;
                        }
                        char[] mass = st.ToCharArray();
                        for (int j = 0; j < mass.Length; j++)
                        {
                            if (mass[j] != ';' && mass[j] != '\n')
                                elem[ind] = elem[ind] + mass[j];
                            else
                            {
                                ind++;
                            }
                        }
                        Car car = new Car(elem[0], Convert.ToInt32(elem[1]), Convert.ToInt32(elem[2]), elem[3], Convert.ToInt32(elem[4]));
                        ind = 0;
                        for (int j = 0; j < 5; j++)
                            elem[j] = "";
                        cars.Add(car);
                    }
                }
            }
            catch (IOException)
            {
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
            repositroy += "+ Работа через текстовый файл\n";
            repositroy += "++++++++++++++++++++++++++++++\n";
            return repositroy;
        }
    }
}
