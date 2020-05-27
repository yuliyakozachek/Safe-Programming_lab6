using System;
namespace Yuliya
{
    // визначення інтерфейсу
    interface IDemo
    {
        void Show(); //оголошення методу
        int A { get; } //оголошення властивості, доступного тільки для читання
        int this[int i] { get; set; } //оголошення індексатора, доступного для
        //читання-запису
    }
     public interface IMeasurable
    {
    double Perimeter();
    double Area();
    }
    public interface ICircumcircleIncircle
    {
        double R { get; } // радіус описаного кола
        double r { get; } // радіус вписаного кола
    }
    // клас DemoPoint успадковує інтерфейс IDemo

    class   Square : IDemo, IMeasurable, ICircumcircleIncircle, IComparable
    {
        protected int a;
        public int A
        {
            get
            {
                return a;
            }
        }
        public  Square(int a)
        {
            this.a = a;
        }
        public void Show()
            {
                Console.WriteLine($"Cторона квадрата = { a}");
            }
        public double Perimeter()
            {
                return 4*a;
            }
        public double Area()
            {
                return Math.Pow(a,2);
            }
        public double r
        {
            get
            {
                return Convert.ToDouble(a)/2;
            }
        }
        public double R
        {
            get
            {
                return Convert.ToDouble(a)*Math.Sqrt(2)/2;
            }
        }     
        public int this[int i]
        {
            get
            {
                if (i == 0) return a;
                else throw new Exception("Неприпустиме значення індексу");
            }
            set
            {
                if (i == 0) a = value;
                else throw new Exception("Неприпустиме значення індексу ");
            }
        }
            public int CompareTo(object obj)
            {
                Square square = (Square)obj; 
                if (this.Perimeter() == square.Perimeter()) 
                 {   return 0;}
                else if (this.Perimeter() > square.Perimeter()) 
                    {return 1;}
                else 
                    {return -1;}
            }        
    }
 
    
    class Program
    {
        static void Main()
        {
            // створення масиву інтерфейсних посилань
            Square[] sq = new Square[4];
            Random  random = new Random();
            // заповнення масиву
            for (int i = 0; i < 4; i++)
                sq[i] = new Square(random.Next(0,10)); 
            // перегляд масиву
            foreach (Square a in sq)
            {
                a.Show();
                Console.WriteLine("Периметр = "+a.Perimeter());
                Console.WriteLine("Площадь = "+a.Area());
                Console.WriteLine("Радиус описанной окружности = "+Math.Round((a.R),2));
                Console.WriteLine("Радиус вписанной окружности = "+a.r);
                Console.WriteLine();
            }
            Console.WriteLine("Сортировка квадратов по периметру:");
            Array.Sort(sq);
            foreach (Square x in sq)
            {
                x.Show();
            }
        }
    }
}
