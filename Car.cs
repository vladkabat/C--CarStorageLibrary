using System;

namespace CarStorageLibrary
{
    [Serializable]
    class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }

        public int Power { get; set; }
        public double Prise { get; set; }
        public string Color{ get; set; }

        public Car() { }

        public Car(string mark, int power, double prise, string color, int id)
        {
            Mark = mark;
            Power = power;
            Prise = prise;
            Color = color;
            Id = id;
        }

       public override string ToString()
        {
            return string.Format("|{0,7}|{1,10}|{2,11}|{3,9}|{4,7}|", Mark, Power, Prise, Color, Id);
        }
    }
}
