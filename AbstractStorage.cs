using System;
using System.Collections.Generic;

namespace CarStorageLibrary
{
    abstract class AbstractStorage : IStorage
    {
        protected abstract List<Car> Load();
        public abstract bool OutputElements();
        public abstract bool Get(int id);
        public abstract bool Filtration(int i, object name);
        public abstract void Save();
        public abstract int GetEndId();
        string lastTime;

        public Car GetId(int id)
        {
            List<Car> cars = Load();
            foreach (Car car in cars)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }
            return null;
        }
        
        public bool AddNewElement(Car car)
        {
            List<Car> cars = Load();
            cars.Add(car);
            return true;
        }

        public bool Sort(int i)
        {
            List<Car> cars = Load();
            switch (i)
            {
                case 1:
                    {
                        cars.Sort((a, b) => a.Mark.CompareTo(b.Mark));
                        if (cars.Count > 0)
                            return true;
                        else return false;
                    }
                case 2:
                    {
                        cars.Sort((a, b) => a.Power.CompareTo(b.Power));
                        if (cars.Count > 0)
                            return true;
                        else return false;
                    }
                case 3:
                    {
                        cars.Sort((a, b) => a.Prise.CompareTo(b.Prise));
                        if (cars.Count > 0)
                            return true;
                        else return false;
                    }
                case 4:
                    {
                        cars.Sort((a, b) => a.Color.CompareTo(b.Color));
                        if (cars.Count > 0)
                            return true;
                        else return false;
                    }
                case 5:
                    {
                        cars.Sort((a, b) => a.Id.CompareTo(b.Id));
                        if (cars.Count > 0)
                            return true;
                        else return false;
                    }
                default:
                    return false;
            }
        }

        public List<Car> FiltrationRealis(int i, object name)
        {
            List<Car> cars = Load();
            List<Car> newCars = new List<Car>();
            switch (i)
            {
                case 1:
                    {
                        for (int j = 0; j < cars.Count; j++)
                        {
                            if ((cars[j].Mark).Equals(name))
                            {
                                newCars.Add(cars[j]);
                            }
                        }
                        if (newCars.Count < 1)
                            return null;
                        else return newCars;
                    }
                case 2:
                    {
                        for (int j = 0; j < cars.Count; j++)
                        {
                            if (cars[j].Power == (int)name)
                            {
                                newCars.Add(cars[j]);
                            }
                        }
                        if (newCars.Count < 1)
                            return null;
                        else return newCars;
                    }
                case 3:
                    {
                        for (int j = 0; j < cars.Count; j++)
                        {
                            if (cars[j].Prise == (int)name)
                            {
                                newCars.Add(cars[j]);
                            }
                        }
                        if (newCars.Count < 1)
                            return null;
                        else return newCars;
                    }
                case 4:
                    {
                        for (int j = 0; j < cars.Count; j++)
                        {
                            if ((cars[i].Color).Equals(name))
                            {
                                newCars.Add(cars[j]);
                            }
                        }
                        if (newCars.Count < 1)
                            return null;
                        else return newCars;
                    }
            }
            return null;
        }

        public string UpdateDateChange()
        {
            return lastTime;
        }

        public void lastDate()
        {
            lastTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }


        public bool Update(int id, int i, object otherName)
        {
            List<Car> cars = Load();
            foreach (Car j in cars)
            {
                if (j.Id == id)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                j.Mark = otherName.ToString();
                                lastDate();
                            }
                            return true;
                        case 2:
                            {
                                j.Power = Convert.ToInt32(otherName.ToString());
                                lastDate();
                            }
                            return true;
                        case 3:
                            {
                                j.Prise = Convert.ToInt32(otherName.ToString());
                                lastDate();
                            }
                            break;
                        case 4:
                            {
                                j.Color = otherName.ToString();
                                lastDate();
                            }
                            return true;
                    }
                }
            }
            return false;
        }


        public bool Delete(int id)
        {
            List<Car> cars = Load();
            foreach (Car car in cars)
            {
                if (car.Id == id)
                {
                    cars.Remove(car);
                    return true;
                }
            }
            return false;
        }
    }
}
